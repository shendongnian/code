    class Song : INotifyPropertyChanged
    {
        public string Title{get;set}
        [Browsable(false)]
        public string Text{get;set;}
        ...
    
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
