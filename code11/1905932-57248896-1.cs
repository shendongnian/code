    class ViewModel : INotifyPropertyChanged
    {
      public ViewModel()
      {
        this.ClsTabs = new ObservableCollection<Tab>();
    
        ClsTabs.Add(new Tab("Animals", new List<string[]>() { new string[] { "Name", "Tiger" }, new string[] { "Tail", "Yes" } }));
        ClsTabs.Add(new Tab("Vegetables", new List<string[]>() { new string[] { "Name", "Tomato" }, new string[] { "Color", "Red" }, new string[] { "Taste", "Good" } }));
        ClsTabs.Add(new Tab("Cars", new List<string[]>() { new string[] { "Name", "Tesla" } }));
      }
    
      private ObservableCollection<Tab> clsTabs;
    
      public ObservableCollection<Tab> ClsTabs
      {
        get => this.clsTabs;
        set
        {
          if (Equals(value, this.clsTabs)) return;
          this.clsTabs = value;
          OnPropertyChanged();
        }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      [NotifyPropertyChangedInvocator]
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
