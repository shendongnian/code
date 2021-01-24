    public void AddToList(string value)
    {
        _listOfStrings.Add(financialProductType);
        OnPropertyChanged("EnableProperty1");
        OnPropertyChanged("EnableProperty2");
        // etc
    }
