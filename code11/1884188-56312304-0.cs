    public ObservableCollection<string> Word
            {
                get => _word;
                set
                {
                    _word= value;
                    RaisePropertyChanged("Word");
                }
            }
