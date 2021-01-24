    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        var itemsControl = AssociatedObject as ItemsControl;
        if (itemsControl == null) return;
        itemsControl.ItemContainerGenerator.ItemsChanged += OnCollectionChanged;
    }
    private void OnCollectionChanged(object sender, ItemsChangedEventArgs e)
    {
      if (e.Action == NotifyCollectionChangedAction.Add)
      {
        var border = (Border)VisualTreeHelper.GetChild(AssociatedObject, 0);
        var scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
        // Only scroll when we're scrolled to the bottom of the listbox
        if (scrollViewer.VerticalOffset == scrollViewer.ScrollableHeight)
        {
          scrollViewer.ScrollToBottom();
        }
      }
    }
