        private ObservableCollection<string> myObservableCollection = new ObservableCollection<string>{ "one", "two", "tree" };
        public ObservableCollection<string> MyObservableCollection
        {
            get => this.myObservableCollection;
            set => SetField(ref this.myObservableCollection, value);
        }
