    private ObservableCollection<DayOfWeek> _weekDays;
    // In the constructor:
    _weekDays = new ObservableCollection<DayOfWeek>();
    _weekDays.AddRange(new DayOfWeek[] {
        DayOfWeek.Sunday,
        DayOfWeek.Monday,
        DayOfWeek.Tuesday,
        DayOfWeek.Wednesday,
        DayOfWeek.Thursday,
        DayOfWeek.Friday,
        DayOfWeek.Saturday
    });
    // Properties of your VM:
    public ObservableCollection<DayOfWeek> WeekDays
    {
        get
        {
            return _weekDays;
        }
    }
    public DayOfWeek SelectedDay
    {
        get;
        set;
    }
