    public DateTime? ReleaseDate
    {
        get
        {
            return _ReleaseDate;
        }
        set
        {
            // if value is null, then that's all good, _ReleaseDate will be null as well
            _ReleaseDate = value; 
        }
    }
