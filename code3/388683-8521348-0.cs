    MyComputer.PropertyChanged += Computer_PropertyChanged;
    
    void Computer_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "Online")
        {
            // Do Work
        }
    }
