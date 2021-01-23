    public static class Globals
    {
        public static MainWindow MainWindow;
    }
    
    public partial class MainWindow : Window
    {
        public bool Adam = true;
    
        public MainWindow()
        {
            Globals.MainWindow = this;
            InitializeComponent();
        }
    
        public class NextEnabled : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return Globals.MainWindow;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return true;
            }
        }
    }
