    public QuoteViewModel : INotifyPropertyChanged
    {
      private Quote quote;
      public event EventHandler PropertyChanged;
      public INotifyPropertyChanged Quote
      {
        get { return quote; }
        set
        {
          quote = value;
          PropertyChanged("Quote");
        }
      }
    }
