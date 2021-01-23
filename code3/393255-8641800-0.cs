    public void TimeChanged(object sender, PropertyChangedEventArgs e)
    {
    
    //un register
    TimeChanged -= new PropertyChangedEventHandler(PropertyChanged};
    
    // Process lots of calculations
    
    //re-register
    TimeChanged += new PropertyChangedEventHandler(PropertyChanged};
    
    }
