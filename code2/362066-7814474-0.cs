    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }
        private EventHandler modelChanged;
        protected void Init()
        {
            Trace.WriteLine(string.Format("ChangeManager init on thread={0}",
                     Thread.CurrentThread.ManagedThreadId));
            var uiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            modelChanged = (o, args) => Task.Factory.StartNew(() =>
            {
                Trace.WriteLine(string.Format("ModelChanged on thread={0}", 
                    Thread.CurrentThread.ManagedThreadId));
                if (ModelChanged != null)
                {
                    ModelChanged(o, args);
                }
            },
                CancellationToken.None,
                TaskCreationOptions.None,
                uiTaskScheduler);
        }
        public event EventHandler ModelChanged;
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var t = new Thread(
                obj =>
                     {
                          Trace.WriteLine(string.Format(
                              "Launching handler on thread={0}", 
                              Thread.CurrentThread.ManagedThreadId));
                          modelChanged(null, EventArgs.Empty);
                     });
            t.Start();
        }
    }
