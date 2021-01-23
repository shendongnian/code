    protected ChangedEventHandler _change;
    public ChangedEventHandler Change
    {
        add { _change += value; }
        remove { _change -= value; }
    }
