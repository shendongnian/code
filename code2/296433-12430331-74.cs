    private DayOfWeek dayOfWeek;
    public DayOfWeek SelectedDay
    {
      get { return dayOfWeek; }
      set
      {
        if (dayOfWeek != value)
        {
          dayOfWeek = value;
          OnPropertyChanged(nameof(SelectedDay));
        }
      }
    }
