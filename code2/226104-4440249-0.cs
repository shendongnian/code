    public static class ItemSelector
    {
        public static DependencyProperty MakeSelectionProperty = 
            DependencyProperty.RegisterAttached("MakeSelection", 
            typeof(bool?), 
            typeof(ItemSelector), 
            new PropertyMetadata(null, OnMakeSelectionPropertyChanged));
        public static DependencyProperty ItemsControlProperty = 
            DependencyProperty.RegisterAttached("ItemsControl", 
            typeof(ItemsControl), 
            typeof(ItemSelector));
        public static void SetMakeSelection(
            DependencyObject d, bool value)
        {
            d.SetValue(MakeSelectionProperty, value);
        }
        public static void SetItemsControl(
            DependencyObject d, ItemsControl value)
        {
            d.SetValue(ItemsControlProperty, value);
        }
        private static void OnMakeSelectionPropertyChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var itemsControl = d.GetValue(ItemsControlProperty) 
                as ItemsControl;
            if (itemsControl == null)
                return;
            ((ListBoxItem) itemsControl.ContainerFromElement(d))
                .IsSelected = true;
        }
