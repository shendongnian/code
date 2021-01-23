    private string _name;
    public string Name
    {
        // ...
        set
        {
            // if (_name != value) such a check probably does not happen
            {
                _name = value;
                MarkPropertyAsModified(...);
            }
        }
    }
