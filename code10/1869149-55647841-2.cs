    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {     
      var selected = listBoxobj.SelectedItems.Cast<Object>().ToArray();
      foreach (var item in selected)
      {
          listBoxobj.Items.Remove(item);
      }
    }
