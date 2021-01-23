    public Type CreateProxyType()
    {
       int memberCount = 0;
       foreach (MethodInfo method in MethodsToIntercept())
       {
            OverrideMethod(method, memberCount++);
       }
       foreach (PropertyInfo property in PropertiesToIntercept())
       {
            OverrideProperty(property, memberCount++);
       }
       // Add this 
       foreach (EventInfo evt in EventsToIntercept())
       {
            AddEvent(evt);
       }
      // -- SNIP --
    }
