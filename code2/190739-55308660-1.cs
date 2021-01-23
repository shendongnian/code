    public static TAction RemapGenericMember<TAction>(object parent, Type target, TAction func) where TAction : Delegate { 
    	var genericMethod = func?.Method?.GetGenericMethodDefinition()?.MakeGenericMethod(target);
    	if (genericMethod.IsNull()) {
    		throw new Exception($"Failed to build generic call for '{func.Method.Name}' with generic type '{target.Name}' for parent '{parent.GetType()}'");
    	}
    	return (TAction)genericMethod.CreateDelegate(typeof(TAction), parent);
    }
