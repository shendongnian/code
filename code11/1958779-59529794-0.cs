        public bool IsBusy
        {
            set { isBusy = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy))); }
            get { return isBusy; }
        }
