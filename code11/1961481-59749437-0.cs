    public partial class MainWindow
    {
      // Shared and reused view model instance
      private FilterWindowViewModel DialogViewModel{ get; set; }
     
      public MainWindow()
      { 
        this.DialogViewModel = new FilterWindowViewModel();
      }
    
      private void ShowDialog()
      {
        var dialog = new FilterWindowView() { DataContext = this.DialogViewModel };
        if (dialog.ShowDialog() ?? false)
        {
          //...
        }
      }
    }
