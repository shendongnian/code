    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            btnExe.Command = new RelayCommandAsync(ThingsToDo);
        }
        private async Task ThingsToDo()
        {
            // simulate a long running operation
            await Task.Delay(TimeSpan.FromSeconds(3));
        }
    }
