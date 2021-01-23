    private int _currentPage;
    
    public int CurrentPage
    {
        get
        {
            return _currentPage;
        }
    }
    
    public void SetCurrentPage(string value)
    {
            _currentPage = (string.IsNullOrEmpty(value)) ? 1 : Convert.ToInt32(value);
    }
