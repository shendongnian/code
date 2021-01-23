    private string name;
    public string Name
    {
        get { return name; }
        set 
        {
            if (!String.Equals(value, name)) // if the value gets changed...
            {
                name = value;
                OnNameChanged(); // raise the event!!!
            }
        }
    }
