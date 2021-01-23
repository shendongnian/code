    using System;
    using System.Windows;
    using System.Windows.Data;
    using System.Xml.Linq;
    
    namespace WPF1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                DataContext = this;
            }
    
            public XElement Stats
            {
                get { return XElement.Parse("<Stats HP=\"55000\" MP=\"2500\" SP=\"2500\" Strength=\"212\" Vitality=\"125\" Magic=\"200\" Spirit=\"162\" Skill=\"111\" Speed=\"109\" Evasion=\"100\" MgEvasion=\"100\" Accuracy=\"100\" Luck=\"55\" />"); }
            }
        }
    
        public class AttributesToEnumerableConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return (value as XElement).Attributes(); 
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
