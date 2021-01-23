    private DateTime _dob;
    public DateTime dob
    {
        get
        {
            if(_dob!= null) return _dob;
        }
        set
        {
            if(value.Ticks < DateTime.Today.Ticks)
            {
                 _dob= value;
            }
            else
            {
                   throw new Exception("Date of Birth should be less then today's date");
            }
        }
    }
