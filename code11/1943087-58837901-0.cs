    private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var selector = (Selector)d;
        var obs = e.NewValue as INotifyCollectionChanged;
        if (obs != null)
        {
            void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                var dataGrid = selector;
                //...
            }
            obs.CollectionChanged += CollectionChanged;
        }
    }
