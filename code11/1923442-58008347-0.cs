    public class MyClass : INotifyPropertyChanged
    {
      private int intValue;
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      public int MyIntValue
      {
        get => intValue;
        set
        {
          intValue = value;
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MyIntValue)));
        }
      }
    }
