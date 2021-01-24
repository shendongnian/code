    public partial class SearchPanel : UserControl
    {
      public SearchPanel()
      {
        InitializeComponent();
      } 
    
      private void ShowMessage_OnButtonClick(object sender, RoutedEventArgs e)
      {
        this.MessageTextBlock = "This is a message for display in the UI";
      }
    }
