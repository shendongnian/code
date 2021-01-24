    public void RaisePropertyChange(string prop)
    {
        try
        {          
            IsUpdated = true;     
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }                
        }
        catch (Exception ex)
        {
            throw ex;
        }            
    }
