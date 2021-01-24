    public Class MyViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<MyClass> Items { get; }
        public RelayCommand<MyClass> DeleteCommand
        {
            get
            {
                return new RelayCommand<MyClass>((o) =>
                    {
                        // ...
                    });
            }
        }
    }
