        set
        {
            if (_manager.WorkPlace==null)
            {
                _manager.WorkPlace = this;
                _manager = value;
            }
            else
                throw new ArgumentException();
        }
