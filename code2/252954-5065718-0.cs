    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                //this is the full namespace name of UserControl.
                // you could use something like String.Format("WpfApplication1.{0}", "uc1") to put in a function and pass through.
                string ucName = "WpfApplication1.uc1";
    
                Type newType = Type.GetType("WpfApplication1.uc1", true, true);
    
                object o = Activator.CreateInstance(newType);
    
                //Use the object to how ever you like from here on wards.
    
    
            }
        }
    }
