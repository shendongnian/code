    class LastElementSelector : DataTemplateSelector
    {
        public DataTemplate NormalTemplate { get; set; }
        public DataTemplate LastTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return IsLast(container) ? LastTemplate : NormalTemplate;
        }
        bool IsLast(DependencyObject container)
        {
            var itemsControl = FindParentOrSelf<ItemsControl>(container);
            var idx = itemsControl.ItemContainerGenerator.IndexFromContainer(container);
            var count = itemsControl.Items.Count;
            return idx == count - 1;
        }
        T FindParentOrSelf<T>(DependencyObject from) where T : DependencyObject
        {
            for (var curr = from; curr != null; curr = VisualTreeHelper.GetParent(curr))
                if (curr is T t)
                    return t;
            return null;
        }
    }
