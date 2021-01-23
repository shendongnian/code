    public class DigitalNumberViewModel : INotifyPropertyChanged
    {
      private int _numberToDisplay;
      public int NumberToDisplay
      { 
        get { return _numberToDisplay; }
        set 
        {
            _numberToDisplay = value;
            OnPropertyChanged("");
        }
      }
      public Visibility Line1Visibility 
      {
        get 
        {
          switch (NumberToDisplay)
          {
            case 0:
              return Visibility.Visible;
            case 1:
              return Visibility.Hidden;
            //... and so on
          }
        }
      }
      public Visibility Line2Visibility
      { .... }
      // ... and so on
    }
