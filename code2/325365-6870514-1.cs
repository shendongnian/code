    private SomeSpecializedList specializedList;
    public IList<string> SomeList
    {
        get {return specializedList;}
        private set {specializedList = value as SomeSpecializedList;}
    }
    public SomeApiObject()
    {
        SomeList = new SomeSpecializedList<string>();
    }
