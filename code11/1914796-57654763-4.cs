    class LabelData : INotifyPropertyChanged
    {
      private string label;
      public string Label
      {
        get => this.label;
        set
        {
          this.label = value;
          OnPropertyChanged();
        }
      }
    
      private ICommand myCommand;
      public ICommand MyCommand
      {
        get => this.myCommand;
        set
        {
          this.myCommand = value;
          OnPropertyChanged();
        }
      }
    
      // Constructor
      // Initialize the data binding source of the ListBoxItems
      public void LabelData(string label)
      {
        this.Label = label;
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
