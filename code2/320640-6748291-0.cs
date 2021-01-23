            get
            {
                return (IObservableCollection<StringLineInfo>)itmCtrol.ItemsSource;
            }
            set
            {
                itmCtrol.ItemsSource = value;
            }
        }
