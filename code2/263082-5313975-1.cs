    object o = ...
    var unsubscribedEvents = 
      from e in o.GetType().GetEvents()
      where Attribute.IsDefined(e, typeof(RequiredEventSubscriptionAttribute))
      let field = o.GetType()
                   .GetField(e.Name, BindingFlags.NonPublic | BindingFlags.Instance)
                   .GetValue(o)
      where field == null
      select field;
    
    var isValid = !unsubscribedEvents.Any();
