    var tArgs = new List<Type>();
    foreach (var param in method.GetParameters())
        tArgs.Add(param.ParameterType);
    tArgs.Add(method.ReturnType);
    var delDecltype = Expression.GetDelegateType(tArgs.ToArray());
    return Delegate.CreateDelegate(delDecltype, method);
