    private Status _status;
    public string Status
    {
        get { return _status; }
        private set {
            _status = ParseRag(value);
        }
    }
