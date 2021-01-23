    set
    {
        if (value == null)  // Edit: Add manager release capability to change factories
        {
            if(_manager != null)
               _manager.WorkPlace = null;
            _manager = null;
        }
        else if (value.WorkPlace == null)
        {
            _manager = value;
            _manager.WorkPlace = this;
        }
        else
            throw new ArgumentException();
    }
