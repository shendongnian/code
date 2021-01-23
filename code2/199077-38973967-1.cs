    public static class ListViewExtensions
    {
        public static readonly DependencyProperty AutoScrollToEndProperty = DependencyProperty.RegisterAttached("AutoScrollToEnd", typeof(bool), typeof(ListViewExtensions), new UIPropertyMetadata(OnAutoScrollToEndChanged));
        private static readonly DependencyProperty AutoScrollToEndHandlerProperty = DependencyProperty.RegisterAttached("AutoScrollToEndHandler", typeof(NotifyCollectionChangedEventHandler), typeof(ListViewExtensions));
        public static bool GetAutoScrollToEnd(DependencyObject obj) => (bool)obj.GetValue(AutoScrollToEndProperty);
        public static void SetAutoScrollToEnd(DependencyObject obj, bool value) => obj.SetValue(AutoScrollToEndProperty, value);
        private static void OnAutoScrollToEndChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            var listView = s as ListView;
            if (listView == null)
                return;
            var source = (INotifyCollectionChanged)listView.Items.SourceCollection;
            if ((bool)e.NewValue)
            {
                NotifyCollectionChangedEventHandler scrollToEndHandler = delegate
                {
                    if (listView.Items.Count <= 0)
                        return;
                    listView.Items.MoveCurrentToLast();
                    listView.ScrollIntoView(listView.Items.CurrentItem);
                };
                source.CollectionChanged += scrollToEndHandler;
                listView.SetValue(AutoScrollToEndHandlerProperty, scrollToEndHandler);
            }
            else
            {
                var handler = (NotifyCollectionChangedEventHandler)listView.GetValue(AutoScrollToEndHandlerProperty);
                source.CollectionChanged -= handler;
            }
        }
    }
