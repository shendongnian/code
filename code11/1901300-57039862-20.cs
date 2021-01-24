    public class ViewModel : INotifyPropertyChanged
    {
      public ViewModel()
      {
        this.Entries = new ObservableCollection<KeyValuePair<string, string>>()
        {
          new KeyValuePair<string, string>("string", "value1"),
          new KeyValuePair<string, string>("integer", "value2"),
          new KeyValuePair<string, string>("string", "value3"),
          new KeyValuePair<string, string>("decimal", "value4"),
        };
      }
      #region INotifyPropertyChanged
    
      public event PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    
      #endregion
      private ObservableCollection<string> entries;
      public ObservableCollection<string> Entries
      {
        get => this.entries;
        set
        {
          this.entries = value;
          OnPropertyChanged();
        }
      }
    }
