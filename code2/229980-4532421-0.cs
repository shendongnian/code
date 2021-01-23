    private DateTime _fechaPago;
    
    public DateTime FechaPago
    {
        get { return this._fechaPago; }
        
        set
        {
            this._fechaPago = value;
            this.OnPropertyChanged("FechaPago");
        }
    }
    protected void OnPropertyChanged(string propertyName)
    {
        if (this.PropertyChanged != null)
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
