using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2026_WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, int> drinks = new Dictionary<string, int>()
        {
            {"紅茶大杯",60},
            {"紅茶小杯",40},
            {"綠茶大杯",60},
            {"綠茶小杯",40},
            {"可樂大杯",50},
            {"可樂小杯",30}
        };

        Dictionary<string, int> orders = new Dictionary<string, int>();
        string resultMessage = "";
        string typeMessage = "內用";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            orders.Clear();
            resultMessage = "";

            double total = 0.0;
            string discountMessage = "沒有折扣";
            int index = 1;
            double sellPrice = 0.0;

            //檢視飲料選單內，把正確的飲料訂單品項加入order內
            for (int i=0; i <DrinkMenuStackPanel.Children.Count; i++)
            {
                var sp = DrinkMenuStackPanel.Children[i] as StackPanel;
                var cb = sp.Children[0] as CheckBox;
                var sl = sp.Children[2] as Slider;

                int quantity = (int)sl.Value;
                if (cb.IsChecked == true && quantity > 0)
                {
                    string drinkName = cb.Content.ToString();
                    int price = drinks[drinkName];
                    orders.Add(drinkName, quantity);
                }
            }
            //檢視orders，把所有訂單細項內容計算出細項總和
            resultMessage += $"訂購方式：{typeMessage}，訂購清單如下：\n";
            foreach (var item in orders)
            {
                string drinkName = item.Key;
                int price = drinks[drinkName];
                int quantity = item.Value;

                int subTotal = price * quantity;
                total += subTotal;
                resultMessage += $"{index}. {drinkName}: {price}元 X {quatity}杯 = {subTotal}元 \n";
                index++;
                
            }
            resultMessage += $"總計：{total}元\n";
            ResultTextBlock.Text = resultMessage;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var rb = sender as RadioButton;
            TypeMessage = rb.Content.ToString();
        }

        
    }
}