    private ObservableCollection<UserViewModel> _users;
    public ObservableCollection<UserViewModel> Users
    {
        get => _users = _users ?? GetUsersFromDatabase(); // Gets users from the database if not already initialized
        set
        {
             _users = value;
             NotifyPropertyChanged();
        }
    }
