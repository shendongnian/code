    public partial class Chat : Page
    {
      public Chat()
      {
        this.Loaded += OnPageLoaded;
      }
    
      // I recommend to move page initialization to the code location where you load pages instead of doing it in the Loaded event handler
      private void OnPageLoaded(object sender, RoutedEventArgs e)
      {        
        if (this.DataContext is ChatPageViewModel viewModel 
            && viewModel.InitializePageCommand.canExecute(null))
        {
          viewModel.InitializePageCommand.Execute(null);
        }
      }
    }
}
