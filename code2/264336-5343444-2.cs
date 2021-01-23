    public void DoSomething(Type[] types)
    {
       //null-checks here
      
        // Or perhaps you want IsSubclassOf...
       if(types.Any(t => !typeof(BaseClass).IsAssignableFrom(t))
            throw new ArgumentException(...);           
    }
