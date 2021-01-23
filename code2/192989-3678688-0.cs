    public int Property1
    {
        get { return this.property1; }
        set
        {
            if (this.property1 != value)
            {
                this.property1 = value;
                RaisePropertyChanged("Property1");
            }
        }
    }
    private void RaisePropertyChanged(string propertyName)
    {
         if (PropertyChanged != null)
         {
             PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
         }
         DoStuff(); // Call DoStuff here.
    }
