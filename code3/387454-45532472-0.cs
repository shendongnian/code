    public class ObservableCollectionEX<T> : ObservableCollection<T>
    {
        #region Constructors
        public ObservableCollectionEX() : base()
        {
            CollectionChanged += ObservableCollection_CollectionChanged;
        }
        public ObservableCollectionEX(IEnumerable<T> c) : base(c)
        {
            CollectionChanged += ObservableCollection_CollectionChanged;
        }
        public ObservableCollectionEX(List<T> l) : base(l)
        {
            CollectionChanged += ObservableCollection_CollectionChanged;
        }
        #endregion
        public new void Clear()
        {
            foreach (var item in this)
            {
                if (item is INotifyPropertyChanged i)
                {
                    if (i != null)
                        i.PropertyChanged -= Element_PropertyChanged;
                }
            }
            base.Clear();
        }
        private void ObservableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
                foreach (var item in e.OldItems)
                {
                    if (item != null && item is INotifyPropertyChanged i)
                    {
                        i.PropertyChanged -= Element_PropertyChanged;
                    }
                }
            if (e.NewItems != null)
                foreach (var item in e.NewItems)
                {
                    if (item != null && item is INotifyPropertyChanged i)
                    {
                        i.PropertyChanged -= Element_PropertyChanged;
                        i.PropertyChanged += Element_PropertyChanged;
                    }
                }
        }
        private void Element_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //raise the event
            ItemPropertyChanged?.Invoke(sender, e);
        }
        /// <summary>
        /// the sender is the Item
        /// </summary>
        public PropertyChangedEventHandler ItemPropertyChanged;
    }
