        private static DispatcherTimer _dataUpdateTimer = null;
        private ObservableCollection<Item> _items;
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set
            {
                if (_items == value)
                    return;
                _items = value;
                this.OnPropertyChanged(nameof(Items));
            }
        }
        private void SetupDataUpdateTimer()
        {
            _dataUpdateTimer = new DispatcherTimer();
            _dataUpdateTimer.Tick += OnDataUpdateEvent;
            _dataUpdateTimer.Interval = TimeSpan.FromMilliseconds(10000);
            _dataUpdateTimer.Start();
        }
        private void OnDataUpdateEvent(object sender, EventArgs e)
        {
            this.Items = ... add or remove items
            // ...      
        }
