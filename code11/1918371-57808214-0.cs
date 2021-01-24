    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new Worker().Execute(() => { Thread.Sleep(5000); return 0; }, (ex, jobArray) =>
            {
                MessageBox.Show(Thread.CurrentThread.ManagedThreadId.ToString());
            });
        }
    }
