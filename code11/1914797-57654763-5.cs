    class ViewModel : INotifyPropertyChanged
    {
      private ObservableCollection<LabelData> labels;
      public ObservableCollection<LabelData> Labels
      {
        get => this.labels;
        set
        {
          this.labels = value;
          OnPropertyChanged();
        }
      }
      // Constructor
      // Initialize the data binding source of the ListBox
      public void ViewModel()
      {
        this.Labels = new ObservableCollection<LabelData>() 
        { 
          new LabelData("MicrosoftWindows") { MyCommand = SomeCommand},
          new LabelData("Games") { MyCommand = SomeOtherCommand},
          new LabelData("Video") { MyCommand = SomeOtherCommand},
          new LabelData("Image") { MyCommand = SomeCommand}
        };
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
