    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.AddToDebug("In Button_Click");
            ThreadPool.QueueUserWorkItem(delegate
            {
                ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                ServiceReference1.Service1 asInterface = client;
                this.AddToDebug("Calling server \"synchronously\"...");
                int result = asInterface.EndAdd(asInterface.BeginAdd(45, 67, null, null));
                this.AddToDebug("Result: {0}", result);
                client.CloseAsync();
            });
        }
        private void AddToDebug(string text, params object[] args)
        {
            if (args != null && args.Length > 0)
            {
                text = string.Format(text, args);
            }
            text = string.Format("[{0} - {1}] {2}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString("HH:mm:ss.fff"), text);
            this.Dispatcher.BeginInvoke(() => this.txtDebug.Text = this.txtDebug.Text + text + Environment.NewLine);
        }
    }
