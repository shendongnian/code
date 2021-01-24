    public List<User> Users
    {
        get
        {
            if (_Users == null)
            {
                _Users = dbContext.User.ToList();
            }
            return _Users;
        }
        set
        {
            _Users = value;
            OnPropertyChanged(() => Users);
        }
    }
