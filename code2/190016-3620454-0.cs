    public partial class MainWindow : Window
    {
        MyControl mycontrol;
    
        public MainWindow()
        {
            InitializeComponent();
    
            //// Your logics...
    
            mycontrol.Dispatcher.BeginInvoke((Action)(() =>
                {
                     /// Try invoking timer here...
                }));
        } 
    }
    
    public abstract class MyControl: Control
    {
    
    }
