    public partial class MainWindow
    {
      public MainWindow()
      {
        InitializeComponent();
      }
    
      public MainWindow(Progress<int> progressReporter) : this()
      {
        progressReporter((100, "From MainWindow"));    
    
        // do some stuff that takes a few seconds...
      }
    }
