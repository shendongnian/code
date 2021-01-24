    class ViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
      private DataModel Data { get; set; }
    
      private List<string> propName;
      public List<string> PropName
      {
        get => this.Data;
        set
        { 
          this.Data.PropName = value;
          RaisePropertyChanged();
        }
      }
    }
