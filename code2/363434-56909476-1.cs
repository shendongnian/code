    private int numberOfElephants;
    public int NumberOfElephants {
        get => numberOfElephants; 
    
        set {
            _numberOfElephants = value; 
            OnPropertyChanged(); 
        } 
    }
    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
