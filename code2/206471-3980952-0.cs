    [NonSerialized]
    private EventHandler _nonSerializableeventHandler;
    private EventHandler _eventHandler;
    public event EventHandler MyEvent
    {
        add
        {
            if (value.Method.DeclaringType.IsSerializable)
                _eventHandler += value;
            else
                _nonSerializableeventHandler += value;
        }
        remove
        {
            {
                if (value.Method.DeclaringType.IsSerializable)
                    _eventHandler -= value;
                else
                    _nonSerializableeventHandler -= value;
            }
        }
    } 
