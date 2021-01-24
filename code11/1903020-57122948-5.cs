    private void ScrollToSection(string sectionName)
    {
      CollectionViewSource viewSource = FindResource("CollectionViewSource") as CollectionViewSource;
      CollectionViewGroup selectedGroupItemData = viewSource
        .View
        .Groups
        .OfType<CollectionViewGroup>()
        .FirstOrDefault(group => group.Name.Equals(sectionName));
      GroupItem selectedroupItemContainer = this.ListView.ItemContainerGenerator.ContainerFromItem(selectedGroupItemData) as GroupItem;
      selectedGroupItemContainer.BringIntoView();   
    }
