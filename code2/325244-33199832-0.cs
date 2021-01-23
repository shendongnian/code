     public partial class MainWindow : Window
    {
        static DispatchClass dc;
        public MainWindow()
        {
            InitializeComponent();
            dc = new DispatchClass();
            Thread th = new Thread(AccessDC);
            th.Start();
        }
        private delegate void AccessDCDelegate(object state);
        static private void AccessDC(object state)
        {
            if (dc.Dispatcher.CheckAccess())
                dc.Print("hello");
            else
                dc.Dispatcher.BeginInvoke(new Action(()=> AccessDC(null)));
        }
    }
 
    public class DispatchClass : DispatcherObject
    {
        public void Print(string str)
        {
            MessageBox.Show(str);
        }
    }
