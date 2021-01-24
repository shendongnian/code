    class AdjustableListView : ListView
    {
        public AdjustableListView()
        {
            SizeChanged += OnSizeChanged;
        }
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            var listItem = (ListViewItem)element;
            var binding = new Binding { Source = this, Path = new PropertyPath("FontSize")};
            listItem.SetBinding(ListViewItem.FontSizeProperty, binding);
        }
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            FontSize = Math.Max(12, e.NewSize.Height / 24);
        }
    }
