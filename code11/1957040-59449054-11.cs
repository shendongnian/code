    public partial class MainWindow
    {
      public MainWindow()
      {
        InitializeComponent();
      }
    
      // Do some stuff that takes a few seconds...
      public async Task InitializeAsync(Progress<(int Value, string Message)> progressReporter)
      {
        progressReporter((100, "From MainWindow"));   
      }
    }
