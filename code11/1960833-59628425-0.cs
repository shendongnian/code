    class ViewModel
    {
      public ObservableCollection<DataModel> Items { get; set; }
      public ICommand AddItemCommand => new AsyncRelayCommand(() => this.Items.Add(new DataModel()));    
      public ICommand RemoveItemCommand => new AsyncRelayCommand((item) => this.Items.Remove(item));
    
      public ViewModel()
      {
        this.Items = new ObservableCollection<DataModel>();
      }
    }
