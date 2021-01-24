       public partial class MainWindow : Window, ICommon
    {
    
        public MainWindow()
        {
            InitializeComponent();
            Program test = new Program();
            thisButton.Click += delegate(object sender, RoutedEventArgs e) { test.WhenPressed_1(this); };
        }
    
        public void SetValueInMain()
        {
            // Set Main values
        }
    
        public class Program
        {
            public string Word { get; set; }
            public void WhenPressed_1(ICommon mainWind)
            {
                mainWind.SetValueInMain();
            }
        }
    }
    
    public interface ICommon
    {
        void SetValueInMain();
    }
