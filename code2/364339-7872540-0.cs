    ModelContext context = new ModelContext();
    
    Author entity = new Author();
    
    string entitySetName = "Authors";
    string methodName = "AddObject";
    
    Type contextType = (context as Object).GetType();
    var set = (contextType.GetProperty(entitySetName)).GetValue(context, null);
    Type typeSet = set.GetType();
    MethodInfo method = typeSet.GetMethod(methodName);
    
    ParameterExpression paramo = Expression.Parameter(typeSet, "param");
    ParameterExpression parami = Expression.Parameter(entity.GetType(), "newvalue");
    
    MethodCallExpression methodCall = Expression.Call(paramo, method, parami);
    
    Type typeofClassWithGenericStaticMethod = typeof(Expression);
    MethodInfo methodInfo = typeofClassWithGenericStaticMethod.GetMethods().Where(m => m.Name == "Lambda" && m.IsGenericMethod).First();
    Type genericArguments = typeof(Action<,>).MakeGenericType(typeSet, entity.GetType());
    MethodInfo genericMethodInfo = methodInfo.MakeGenericMethod(genericArguments);
    
    dynamic objectSet = set;
    dynamic returnValue = genericMethodInfo.Invoke(null, new object[] { methodCall, new ParameterExpression[] { paramo, parami } });
    var action = returnValue.Compile();
    
    action(objectSet, entity);
