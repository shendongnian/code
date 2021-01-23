    private string name;
    public event NameChangingEventHandler NameChanging;
    public event NameChangedEventHandler NameChanged;
    public string Name
    {
        get { return name; }
        set
        {
            OnNameChanging(/*...*/);
            name = value;
            OnNameChanged(/*...*/);
        }
    }
    protected virtual void OnNameChanging(/*...*/) { }
    protected virtual void OnNameChanged(/*...*/) { }
