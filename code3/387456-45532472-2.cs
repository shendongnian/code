    private void Element_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        //raise the event
        ItemPropertyChanged?.Invoke(this,sender, e);
    }
    public ListedItemPropertyChangedEventHandler ItemPropertyChanged;  
