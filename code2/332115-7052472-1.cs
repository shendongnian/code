        public bool MapLoaded
        {
            get
            {
                return mapLoaded;
            }
            set
            {
                if (value != mapLoaded)
                {
                    mapLoaded = value;
                    MapLoadedChanged(this, EventArgs.Empty);
                }
            }
        }
        private bool mapLoaded;
        public event EventHandler MapLoadedChanged = delegate {};
        // ^ or implement INotifyPropertyChanged instead
