    public void DoSomething(params BaseClass[] examples)
    {
        //null-checks here
    
       Type[] types = examples.Select(e => e.GetType())
                              .ToArray();
       //...    
    }
