    public class ViewableCollection<T> : ObservableCollection<T>
    {
        private ListCollectionView _View;
        public ViewableCollection(IEnumerable<T> items)
            : base(items) { }
        public ViewableCollection()
            : base() { }
        [XmlIgnore]
        public ListCollectionView View
        {
            get
            {
                if (_View == null)
                {
                    _View = new ListCollectionView(this);
                    _View.CurrentChanged += new EventHandler(InnerView_CurrentChanged);
                }
                return _View;
            }
        }
        [XmlIgnore]
        public T CurrentItem
        {
            get
            {
                return (T)this.View.CurrentItem;
            }
            set
            {
                this.View.MoveCurrentTo(value);
            }
        }
        private void InnerView_CurrentChanged(object sender, EventArgs e)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs("CurrentItem"));
        }
        public void AddRange(object allProducts)
        {
            throw new NotImplementedException();
        }
        public void AddRange(IEnumerable<T> range)
        {
            if (range == null)
                throw new ArgumentNullException("range");
            foreach (T item in range)
            {
                this.Items.Add(item);
            }
            this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        public void ReplaceItems(IEnumerable<T> range)
        {
            if (range == null)
                throw new ArgumentNullException("range");
            this.Items.Clear();
            foreach (T item in range)
            {
                this.Items.Add(item);
            }
            this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        public void RemoveItems(IEnumerable<T> range)
        {
            if (range == null)
                throw new ArgumentNullException("range");
            foreach (T item in range)
            {
                this.Items.Remove(item);
            }
            this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        public void ClearAll()
        {
            IList old = this.Items.ToList();
            base.Items.Clear();
            this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        public void CallCollectionChaged()
        {
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        // necessary for xml easy serialization using [XmlArray] attribute
        public static implicit operator List<T>(ViewableCollection<T> o)
        {
            return o == null ? default(List<T>) : o.ToList();
        }
        // necessary for xml easy serialization using [XmlArray] attribute
        public static implicit operator ViewableCollection<T>(List<T> o)
        {
            return o == default(List<T>) || o == null ? new ViewableCollection<T>() : new ViewableCollection<T>(o);
        }
    }
