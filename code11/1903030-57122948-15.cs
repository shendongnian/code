    // Scroll the selected section to top when the selected item has changed
    private void ScrollToSection()
    {
      CollectionViewSource viewSource = FindResource("CollectionViewSource") as CollectionViewSource;
      CollectionViewGroup selectedGroupItemData = viewSource
        .View
        .Groups
        .OfType<CollectionViewGroup>()
        .FirstOrDefault(group => group.Name.Equals(this.SelectedSettingsCategoryName));
      GroupItem selectedroupItemContainer = this.ListView.ItemContainerGenerator.ContainerFromItem(selectedGroupItemData) as GroupItem;
      ScrollViewer scrollViewer;
      if (!TryFindCildElement(this.ListView, out scrollViewer))
      {
        return;
      }
      // Subscribe to scrollChanged event 
      // because the scroll executed by `BringIntoView` is deferred.
      scrollViewer.ScrollChanged += ScrollSelectedGroupToTop;
      selectedGroupItemContainer?.BringIntoView();
    }
    private void ScrollSelectedGroupToTop(object sender, ScrollChangedEventArgs e)
    {
      ScrollViewer scrollViewer;
      if (!TryFindCildElement(this.ListView, out scrollViewer))
      {
        return;
      }
      scrollViewer.ScrollChanged -= ScrollGroupToTop;
      var viewSource = FindResource("CollectionViewSource") as CollectionViewSource;
      CollectionViewGroup selectedGroupItemData = viewSource
        .View
        .Groups
        .OfType<CollectionViewGroup>()
        .FirstOrDefault(group => group.Name.Equals(this.SelectedSettingsCategoryName));
      var groupIndex = viewSource
        .View
        .Groups.IndexOf(selectedGroupItemData);
      var absoluteVerticalScrollOffset = viewSource
        .View
        .Groups
        .OfType<CollectionViewGroup>()
        .TakeWhile((group, index) => index < groupIndex).Sum(group =>
          (this.ListView.ItemContainerGenerator.ContainerFromItem(group) as GroupItem)?.ActualHeight ?? 0
        );
      scrollViewer.ScrollToVerticalOffset(absoluteVerticalScrollOffset);
    }
    // Generic method to find any `DependencyObject` in the visual tree of a parent element
    private bool TryFindCildElement<TElement>(DependencyObject parent, out TElement resultElement) where TElement : DependencyObject
    {
      resultElement = null;
      for (var childIndex = 0; childIndex < VisualTreeHelper.GetChildrenCount(parent); childIndex++)
      {
        DependencyObject childElement = VisualTreeHelper.GetChild(parent, childIndex);
        if (childElement is Popup popup)
        {
          childElement = popup.Child;
        }
        if (childElement is TElement)
        {
          resultElement = childElement as TElement;
          return true;
        }
        if (TryFindCildElement(childElement, out resultElement))
        {
          return true;
        }
      }
      return false;
    }
