    public ObservableCollection<Something> VMItemsSource {get; set;}
    public Something VMSelectedItem
    {
      get 
      {
        return this.vmSelectedItem;
      }
      set
      {
        this.vmSelectedItem = value;
        this.RaisePropertyChanged(nameof(this.VMSelectedItem));
      }
    }
