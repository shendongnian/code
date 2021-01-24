    private IAzureService _azureService;
    private string _userDisplayNm;
    public MenuViewModel(IAzureService azureService)
    {
        _azureService = azureService;
    }
    public string UserDisplayNm
    {
        get
        {
            return _userDisplayNm;
        }
        set
        {
            if (_userDisplayNm != value)
            {
                _userDisplayNm = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UserDisplayNm)));
            }
        }
    }
    public async void LoadAsync()
    {
        try
        {
            UserDisplayNm = await _azureService.GetUserName();
        }
        catch (Exception exception)
        {
            Debug.WriteLine($"Error while retrieving user name: {exception}")
        }
    }
