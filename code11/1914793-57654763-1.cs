    class ViewModel : INotifyPropertyChanged
    {
      private ObservableCollection<string> labels;
      public ObservableCollection<string> Labels
      {
        get => this.labels;
        set
        {
          this.labels = value;
          OnPropertyChanged();
        }
      }
    
      private ICommand myCommand;
      public ICommand MyCommand
      {
        get => this.labels;
        set
        {
          this.labels = value;
          OnPropertyChanged();
        }
      }
    
      // Constructor
      public void ViewModel()
      {
        // Initialize the data binding source of the ListBox
        this.Labels = new ObservableCollection<string>() 
        { 
          "MicrosoftWindows",
          "Games",
          "Video",
          "Image"
        };
    
        // TODO::Initialize MyCommand
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
