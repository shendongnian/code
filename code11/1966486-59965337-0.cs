    public class SelectingItemAttachedProperty
    {
        public static readonly DependencyProperty SelectingItemProperty = DependencyProperty.RegisterAttached("SelectingItem", typeof(Item), typeof(SelectingItemAttachedProperty), new PropertyMetadata(default(Item), OnSelectingItemChanged));
        public static Item GetSelectingItem(DependencyObject target)
        {
            return (Item)target.GetValue(SelectingItemProperty);
        }
        public static void SetSelectingItem(DependencyObject target, Item value)
        {
            target.SetValue(SelectingItemProperty, value);
        }
        static void OnSelectingItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var grid = sender as DataGrid;
            if (grid == null || grid.SelectedItem == null)
                return;
            grid.Dispatcher.InvokeAsync(() =>
            {
                grid.UpdateLayout();
                grid.ScrollIntoView(grid.SelectedItem, null);
                var row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(grid.SelectedIndex);
                row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            });
        }
    }
