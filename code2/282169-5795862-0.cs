    public static readonly DependencyProperty VisibleItemsProperty =
        DependencyProperty.Register(
        "VisibleItems",
        typeof(IList),
        typeof(MyFilterList),
        new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(VisibleItemsChanged)));
        private static void VisibleItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var myList = d as MyFilterList;
            if (myList == null) return;
            myList.OnVisibleItemsChanged(e.NewValue as IList, e.OldValue as IList);
        }
        protected virtual void OnVisibleItemsChanged(IList newValue, IList oldValue)
        {
            var oldCollection = oldValue as INotifyCollectionChanged;
            if (oldCollection != null)
            {
                oldCollection.CollectionChanged -= VisibleItems_CollectionChanged;
            }
            var newCollection = newValue as INotifyCollectionChanged;
            if (newCollection != null)
            {
                newCollection.CollectionChanged += VisibleItems_CollectionChanged;
            }
        }
