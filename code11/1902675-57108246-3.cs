    public partial class Chat : Page
    {
      public Chat()
      {
        this.Loaded += OnPageLoaded;
      }
    
      private void OnPageLoaded(object sender, RoutedEventArgs e)
      {
        (this.DataContext as ChatPageViewModel).InitializePageCommand.Execute(null);
      }
    }
}
