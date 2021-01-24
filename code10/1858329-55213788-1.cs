    public event PropertyChangedEventHandler PropertyChanged;
    
            public int floor;
            public int Floor
            {
                get { return this.floor;}
                set { this.floor = value;
                    OnPropertyChanged("Floor"); }
            }
            private void OnPropertyChanged(string property)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
