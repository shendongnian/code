    public partial class MainWindow : Window
    {
        CancellationTokenSource source = new CancellationTokenSource();
        SynchronizationContext context = SynchronizationContext.Current;
        Task task;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void DoWork()
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(500); //simulate long running task
                if (source.IsCancellationRequested)
                {
                    context.Send((_) => labelPrg.Content = "Cancelled!!!", null);
                    break;
                }
                context.Send((_) => labelPrg.Content = prg.Value = prg.Value + 1, null);
            }
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            task = Task.Factory.StartNew(DoWork, source.Token);
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            source.Cancel();
        }       
    }
