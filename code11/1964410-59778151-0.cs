    public partial class MainWindow : Window
    {
        public TaskCompletionSource<bool> tcs;
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var progressIndicator = new Progress<List<int>>(ReportProgress);
            Debug.Write("BEGIN\r");
            await StartDataPush(progressIndicator);
            Debug.Write("END\r");
        }
        
        private void ReportProgress(List<int> obj)
        {
            foreach (int item in obj)
            {
                Debug.Write(item + " ");
            }
            Debug.Write("\r");
            Thread.Sleep(500);
            tcs.TrySetResult(true);
        }
        private async Task StartDataPush(IProgress<List<int>> progressIndicator)
        {
            List<int> myList = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                tcs = new TaskCompletionSource<bool>();
                myList.Add(i);
                Debug.Write("Step " + i + "\r");
                progressIndicator.Report(myList);
                await this.tcs.Task;
            }
        }
    }
