    public void DoSomething(object x)
    {
        if(x is Home)
        {
            string ct = ((Home)x).GetClassType;
            ...
        }
    }
   
