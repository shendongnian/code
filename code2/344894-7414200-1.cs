    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ListBox control = (ListBox)sender;
        
        if (control.IsGrouping)
        {
             if (control.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
                  Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(DelayedBringIntoView));
             else
                  control.ItemContainerGenerator.StatusChanged += ItemContainerGenerator_StatusChanged;
        }
        else
            control.ScrollIntoView(control.SelectedItem);
    }
    private void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
    {
        if (ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
            return;
            
        ItemContainerGenerator.StatusChanged -= ItemContainerGenerator_StatusChanged;
        Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(DelayedBringIntoView));
    }
    private void DelayedBringIntoView()
    {
        var item = ItemContainerGenerator.ContainerFromItem(SelectedItem) as ListBoxItem;
        if (item != null)
            item.BringIntoView();
    }
