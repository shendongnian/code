    void Main()
    {
        IList<Constrain> cons;
        SomeObject a;
        
        while(!TryChangeList(cons, a)) { }
    }
    
    // the name tryChangeList reveals the intent that the list will be changed
    private bool TryChangeList(IList<Constrain> constrains, SomeObject a)
    {
        foreach(var con in constrains)
        {
            if(!c.Allows(a))
            {
                a.Change();
                return false;
            }
        }
        return true;
    }
