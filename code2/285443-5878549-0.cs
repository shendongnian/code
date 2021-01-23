    partial class Search : Window
    {
      public Search()
      {
        InitializeComponent();                // provided by Visual Studio
    
        DataContext = new SearchViewModel();  // all-important!
      }
    }
