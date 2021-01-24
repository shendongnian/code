    public event PropertyChangedEventHandler PropertyChanged;
    
            public int floor;
            public int Floor
            {
                get { return this.floor;}
                set { this.floor = value;
                    // The string here should exactly match the property name
                    OnPropertyChanged("Floor"); }
            }
            private void OnPropertyChanged(string property)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
