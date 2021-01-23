    public void DoSomething(object x)
    {
        // null checks here.
        Type t = x.GetType();
        if (t.IsGenericTypeDefinition 
              && t.GetGenericTypeDefinition() == typeof(Home<>))
        {
            string result = (string) t.GetMethod("GetClassType").Invoke(x, null);
            Console.WriteLine(result);
        }
  
        else 
        {
            ... // do nothing / throw etc.
        }
    }
