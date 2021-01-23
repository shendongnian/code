    public void DoSomething(object x)
    {
        // null checks here.
        Type t = x.GetType();
        if (t.IsGenericType &&
              && t.GetGenericTypeDefinition() == typeof(Home<>))
        {
            string result = (string) t.GetProperty("GetClassType")
                                      .GetValue(x, null);
            Console.WriteLine(result);
        }
  
        else 
        {
            ... // do nothing / throw etc.
        }
    }
