    public void OnSave()
    {
        RaisePropertyChanged("my property");
    
        //.. All following code gets executed AFTER RaisePropertyChanged returns execution
    }
