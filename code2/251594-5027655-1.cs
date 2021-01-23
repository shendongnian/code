    private DateTime _dob;
    public DateTime dob
    {
        get
        {
            if(_dob!= null) return _dob;
        }
        set
        {
            if(DateTime.Compare(value, DateTime.Today) <= 0)
            {
                 _dob= value;
            }
            else
            {
                   throw new System.InvalidOperationException("Date of Birth should be less then today's date");
            }
        }
    }
