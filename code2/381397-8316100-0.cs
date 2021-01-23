    public class YourClass : INotifyPropertyChanged
    {
      private int _delta;
      public int Delta
      {
          get { return _delta; }
          set { _delta = value; NotifyPropertyChanged("Delta"); }
      }
      public event PropertyChangedEventHandler PropertyChanged;
      private void NotifyPropertyChanged(String propertyName)
      {
          PropertyChangedEventHandler handler = PropertyChanged;
          if (null != handler)
          {
              handler(this, new PropertyChangedEventArgs(propertyName));
          }
      }
      }
