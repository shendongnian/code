    Dictionary<Type,Action> actions=new Dict...;
    
    Action action;
    if(!actions.TryGetValue(obj.GetType(), out action))
    {
      action=GetActionForType(obj.GetType());
      actions.Add(obj.GetType(), action);
    }
    action();
