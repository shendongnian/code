    public string Name
    {
       get { return _name; }
       set { PropertyChanged.ChangeAndNotify(ref _name, value, "Name"; }
    }
