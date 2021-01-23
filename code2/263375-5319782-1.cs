    public class Contact : INotifyPropertyChanged
    {
      private string _MyValue;
      public string MyValue
      {
        get { return _MyValue; }
        set
        {
          _MyValue = value;
          if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs("MyValue"));
        }
      }
      public event PropertyChangedEventHandler PropertyChanged;
    }
