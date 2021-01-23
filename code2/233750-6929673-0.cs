    if (base.SelectedItem == null)
    {
    if(base.Items.Count != 0)
    {
    (base.ItemContainerGenerator.ContainerFromItem(base.Items[0]) as TreeViewItem).IsSelected = true;
    }
    }
    base.OnItemsChanged(e);
