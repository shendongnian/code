    public partial class MainWindow
    {
      public MainWindow()
      {
        InitializeComponent();
      }
    
      
      public async Task InitializeAsync(IProgress<(int Value, string Message)> progressReporter)
      {
        await Task.Run(
          () =>
          {
            progressReporter.Report((100, "From MainWindow"));
            
            // Run the initialization routine that takes a few seconds   
          }
      }
    }
