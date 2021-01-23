    private List<String> _Parts;
    public IList<String> Parts
    {
        get
        {
            if (_Parts == null)
                _Parts = new List<String>();
            return _Parts;
        }
        private set
        {
            if (value != null)
                _Parts = value;
        }
    }
