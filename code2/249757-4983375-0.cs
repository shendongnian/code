    // Declare the PropertyChanged event
    public event PropertyChangedEventHandler PropertyChanged;
    // OnPropertyChanged will raise the PropertyChanged event passing the
    // source property that is being updated.
    private void OnPropertyChanged(object sender, string propertyName)
    {
        if (this.PropertyChanged != null)
        {
            PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
        }
    }
