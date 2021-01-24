    class ViewModel : INotifyPropertyChanged
    {
      private ObservableCollection<double> values;
      public ObservableCollection<double> Values
      {
        get => this.values;
        set
        {
          this.values = value;
          OnPropertyChanged();
        }
      }
    
      // Constructor
      public void ViewModel()
      {
        // Initialize the data binding source of the DataGrid
        this.Values = new ObservableCollection<double>() { 1.0, 20 };
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
