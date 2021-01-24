    private bool _hireDeclined;
    public bool HireDeclined
    {
        get => _hireDeclined;
        set 
        {
            _hireDeclined = value;
            NotifyPropertyChanged("HireDeclined");
            if (//some condition)
                DateHireDeclineSent = DateTime.Now;
        }
    }
    private DateTime _dateHireDeclineSent;
    public DateTime DateHireDeclineSent
    {
        get => _dateHireDeclineSent;
        set
        {
            _dateHireDeclineSent = value;
            NotifyPropertyChanged("DateHireDeclineSent");
        }
    }
