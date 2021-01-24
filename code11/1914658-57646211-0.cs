    class ViewModel : INotifyPropertyChanged
    {
      private ObservableCollection<string> labelContents;
      public ObservableCollection<string> LabelContents
      {
        get => this.labelContents;
        set
        {
          this.labelContents = value;
          OnPropertyChanged();
        }
      }
    
      // Constructor
      public void ViewModel()
      {
        // Initialize the data binding source of the ListView
        this.LabelContents = new ObservableCollection<string>();
      }
      
      public void CreateLabelDynamically(string labelText)
      {    
        this.LabelContents.Add(labelText);
      }
    }
