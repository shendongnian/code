    const string nameOrConnectionString = "???";
    public MostViewCustom(MVPObjectContext context)
        : base(nameOrConnectionString) // <-- magic here
    {
        this._context = context;
    }
