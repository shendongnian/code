    public List<User> Users
    {
        get
        {
            if (_Users == null)
            {
                _Users = new ObservableCollection<User>(dbContext.User);
            }
            return _Users;
        }
        set
        {
            _Users = value;
            OnPropertyChanged(() => Users);
        }
    }
