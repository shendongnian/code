    public string ContactName
    {
        get { return _contact.Name; }
        set 
        {
            var name = _contact.Name;
            if (Set(ref name, value))
                _contact.Name = name;
        }
    }
