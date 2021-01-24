    public partial class MainWindow
    {
      public MainWindow()
      {
        InitializeComponent();
      }
    
      public MainWindow(Progress<(int Value, string Message)> progressReporter) : this()
      {
        progressReporter((100, "From MainWindow"));    
    
        // do some stuff that takes a few seconds...
      }
    }
