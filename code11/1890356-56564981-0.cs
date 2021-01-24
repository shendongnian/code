    public class PartListViewModel
    {
        private ObservableCollection<Part> _parts;
        public ObservableCollection<Part> Parts
        {
            get { return _parts; }
            set
            {
                if(_parts != null) _parts.CollectionChanged -= OnCollectionChanged;
                _parts = value;
                if (_parts != null) _parts.CollectionChanged += OnCollectionChanged;
                //OnPropertyChanged("Parts");
            }
        }
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (object part in e.NewItems)
                {
                    (part as INotifyPropertyChanged).PropertyChanged
                        += new PropertyChangedEventHandler(PartPropertyChanged);
                }
            }
            if (e.OldItems != null)
            {
                foreach (object part in e.OldItems)
                {
                    (part as INotifyPropertyChanged).PropertyChanged
                        -= new PropertyChangedEventHandler(PartPropertyChanged);
                }
            }
        }
        private void PartPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "PartType")
            {
                //save to database...
            }
        }
    }
