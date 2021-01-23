    private ObservableCollection<Data>data;
        public ObservableCollection<Data>Data{
            get { return data; }
            set
            {
                data=value;
                // Call NotifyPropertyChanged when the property is updated
                NotifyPropertyChanged("Data");
            }
        }
    // Declare the PropertyChanged event
    public event PropertyChangedEventHandler PropertyChanged;
    // NotifyPropertyChanged will raise the PropertyChanged event passing the
    // source property that is being updated.
    public void NotifyPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }  
