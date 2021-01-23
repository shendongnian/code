    public class MyEntity : INotifyPropertyChanged
    {
      private string _name = string.Empty;
      public string Name
      { 
         get
         {
            return _name;
         }
         set
         {
            _name = value;
            OnPropertyChanged("Name");
         }
      }
      public string Information { get; set; }
      public string Details { get; set; }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      protected void OnPropertyChanged(string propertyName)
      {
         PropertyChangedEventHandler handler = PropertyChanged;
         if (handler != null)
         {
            handler(this, new PropertyChangedEventArgs(propertyName));
         }
      }
    }
