    private bool isTimeValid;
    public bool IsTimeValid
    { 
      get { return (Totalstart > Totalend); }
      set
      {
        if(value != isTimeValid)
          {
            isTimeValid = value;
            NotifyPropertyChanged(nameof(IsTimeValid));
          }
       }
     }
