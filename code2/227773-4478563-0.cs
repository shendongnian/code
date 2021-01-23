    Dictionary<Type, Action> typeTests;
    public ClassCtor()
    {
        typeTests = new Dictionary<Type, Action> ();
        typeTests[typeof(int)] = () => DoIntegerStuff();
        typeTests[typeof(string)] = () => DoStringStuff();
        typeTests[typeof(bool)] = () => DoBooleanStuff();
    }
    private void DoBooleanStuff()
    {
       //do stuff
    }
    private void DoStringStuff()
    {
        //do stuff
    }
    private void DoIntegerStuff()
    {
        //do stuff
    }
    public Action CheckTypeAction(Type TypeToTest)
    {
        if (typeTests.Keys.Contains(TypeToTest))
            return typeTests[TypeToTest];
        return null; // or some other Action delegate
    }
