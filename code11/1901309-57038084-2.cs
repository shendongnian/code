    public static class MyCollectionExtension
    {
        public static MyCollection GetMyCollection(DependencyObject obj)
        {
            return (MyCollection)obj.GetValue(MyCollectionProperty);
        }
        public static void SetMyCollection(DependencyObject obj, MyCollection value)
        {
            obj.SetValue(MyCollectionProperty, value);
        }
        public static readonly DependencyProperty MyCollectionProperty =
            DependencyProperty.RegisterAttached(
                "MyCollection",
                typeof(MyCollection),
                typeof(MyCollectionExtension),
                new PropertyMetadata(MyCollectionPropertyChanged));
        public static void MyCollectionPropertyChanged(
            DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var oldCollection = e.OldValue as MyCollection;
            var newCollection = e.NewValue as MyCollection;
            if (oldCollection != null)
            {
                oldCollection.CollectionChanged -= MyCollectionChanged;
            }
            if (newCollection != null)
            {
                newCollection.CollectionChanged += MyCollectionChanged;
            }
        }
        public static void MyCollectionChanged(object o, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                // ...
            }
        }
    }
