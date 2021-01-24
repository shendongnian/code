    private EventHandler _myHandler;
    public event EventHandler MyHandler
    {
        add
        {
            if (_myHandler != null)
                throw new InvalidOperationException("Only one eventhandler is supported");
            _myHandler = value;
        }
        remove
        {
            // you might want to check if the delegate matches the current.
            if (value == null || value == _myHandler)
                _myHandler = null;
            else
                throw new InvalidOperationException("Unable to unregister, wrong eventhandler");
        }
    }
