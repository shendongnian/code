    private bool? _success;
    public bool Success
    {
        get
        {
            return _success.GetValueOrDefault(false);
        }
    }
