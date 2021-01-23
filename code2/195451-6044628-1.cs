    public void OnItemPropertyChanged(Object sender, PropertyChangedEventArgs e)
    {
      System.Diagnostics.Debug.WriteLine("Update called on {0}", sender);
    }
...
    collection.ItemPropertyChanged += OnItemPropertyChanged;
