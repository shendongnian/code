    private string _name;
    public string Name
    {
        // ...
        set
        {
            if (_name != value)
            {
                _name = value;
                MarkPropertyAsModified(...);
            }
        }
    }
