    public event PropertyChangedEventHandler PropertyChanged;  
   
    private void OnPropertyRaised(string propertyname)
    {  
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));  
    } 
     
    public string SubStatus
    {
        get { ... }
        set
        {  
            _SubStatus = value;  
            OnPropertyRaised(nameof(SubStatus));
        }  
    }
