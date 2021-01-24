public partial class TheWindow : Window
{
   private string[,] LongRunningTask()
   {
      // Your LongRunningTask implementation.
   }
   private async Task StartTask()
   {
      progressLabel.Content = "Getting Sheets...";
      try
      {
         _itemsArr = await Task.Run(() => LongRunningTask());
      }
      catch (Exception e)
      {
         MessageBox.Show(e.Message);
      }
      progressLabel.Content = "Done!";
   }
   private void searchButton_Click(object sender, RoutedEventArgs e)
   {
      if (_itemsArr == null)
      {
         // The field is null for some reason. You'll have to decide what to do in this case, but
         // naturally you can't use it if it's null.
         return;
      }
      // Do the search using the field _itemsArr.
   }
   private string[,] _itemsArr = null;
}
