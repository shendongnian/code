    private string name;
    public string Name
    {
        get
        {
            // running additional code, e.g. here I avoid returning 'null' for a name not set
            if(name == null)
                return "(Unknown)";
            return name;
        }
        set
        {
            // checking incoming values, e.g. here I avoid setting an empty name
            name = value != null && value.Length > 0 ? name : null;
            // running more/additional code, e.g. here I raise an event
            if(OnNameChange)
                OnNameChange();
        }
    }
