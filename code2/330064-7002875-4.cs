     protected virtual void OnPropertyChanged(PropertyChangedEventArgs e) 
        { 
            PropertyChanged.Raise(this, e); 
        } 
    
        protected void OnPropertyChanged(string propertyName) 
        { 
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName)); 
        } 
