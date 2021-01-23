    public ICollectionView Users
    {
        get
        {
            if (_viewModelUsers == null)
            {
                _viewModelUsers = new PagedCollectionView(_viewModelUsersSource);
            }
            return _viewModelUsers;
        }
    }
    private ICollectionView _viewModelUsers;
    private ObservableCollection<User> _viewModelUsersSource = new ObservableCollection<User>();
