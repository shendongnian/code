    private void ContactListBox_SelectionChanged
      (object sender, SelectionChangedEventArgs e)
    {
      if (e.AddedItems.Count == 1)
      {
        var container = (FrameworkElement)ContactListBox.ItemContainerGenerator.
                          ContainerFromItem(e.AddedItems[0]);
        StackPanel sp = container.FindVisualChild<StackPanel>();
        TextBox tbName = (TextBox) sp.FindName("tbName");
        TextBlock lblName = (TextBlock)sp.FindName("lblName");
        TextBlock lblNumber = (TextBlock)sp.FindName("lblNumber");
      }
    }
