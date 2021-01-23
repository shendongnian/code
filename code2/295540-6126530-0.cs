    public YourClassConstructor()
    {
       _users = _userRepository.RetrieveUsers();
       _selectedName = _users[0];
    }
    
    public List<User> Users
    {
        get
        {
            return _users;
        }
    }
