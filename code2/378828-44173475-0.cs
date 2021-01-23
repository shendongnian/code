    private void CheckBounds(ItemsControl itemsControl)
        {
            foreach (var item in itemsControl.Items)
            {
                var child = ((FrameworkElement)itemsControl.ItemContainerGenerator.ContainerFromItem(item));
                child.IsEnabled = child.IsControlVisible(itemsControl);
            }
        }
