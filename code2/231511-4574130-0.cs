    void Main()
    {
        IList<Constrain> cons;
        SomeObject a;
        bool done;
        while(!TryChangeList(cons, a))
        {
        }
    }
    
    
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
