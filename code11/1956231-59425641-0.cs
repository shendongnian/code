    public MainWindow()
    {
        InitializeComponent();
        Closing += MainWindow_Closing;
    }
    private bool _doClose = false;
    private async void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (!_doClose)
        {
            e.Cancel = true;
            await ClosingTasks();
        }
    }
    private async Task ClosingTasks()
    {
        await Task.Delay(2000); //await your task here...
        _doClose = true;
        Close();
    }
