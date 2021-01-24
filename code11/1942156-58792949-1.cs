    partial class MainWindow : Window
    {
      public MainWindow()
      {
        InitializeComponent();
        this.Loaded += InitializeOnLoaded();
      }
    
      private void InitilaizeOnLoaded(object sender, EventArgs e)
      {
        (this.DataContext as ViewModel).ButtonClickCommand("clear_filter");
      }
    }
