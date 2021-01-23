    private void NavigateToMyDetail(object sender, SelectionChangedEventArgs e)
    {
       // Make sure that the ListBox change wasn't due to a deselection
       if(e.AddedItems != null && e.AddedItems.Count == 1)
       {
          MyObject selectedItem = (MyObject)e.AddedItems[0];
          // Now you have access to all your MyObject properties
          // and you can pass that to your new page as a parameter
          NavigationService.Navigate(new Uri("DisplayItem.xaml?ItemID=" + selectedItem.id.ToString(), UriKind.Relative));
       }
    }
