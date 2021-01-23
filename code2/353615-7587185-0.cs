    public string Name
    {
        get { return name; }
        set 
        {
            if (! RegEx.IsMatch(value, "\w{1-35}"))
               throw new ArgumentException("Name must be 1-35 alfanum");
            this.name = value;
        }
