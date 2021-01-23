        public static readonly DependencyProperty ItemsTemplateProperty =
            DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), 
                                         typeof(LongListSelector), 
                                         new PropertyMetadata(null, 
                                                              OnItemsTemplateChanged));
        private static void OnItemsTemplateChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ((LongListSelector)obj).OnItemsTemplateChanged();
        }
        private void OnItemsTemplateChanged()
        {
            _flattenedItems = null;
            if (_isLoaded)
            {
                EnsureData();
            }
        }
 
