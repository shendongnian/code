    Type fieldType = ;// This is the type I have discovered
    Type genericType = typeof(Gen<>).MakeGenericType(fieldType);
    object genericInstance = Activator.CreateInstance(genericType);
    MethodInfo mi = genericType.GetMethod("DoSomething",
                                    BindingFlags.Instance | BindingFlags.Public);
    var value = Expression.Constant(instance, fieldType);
    var lambda = Expression.Lambda<Func<int>>(Expression.Call(Expression.Constant(genericInstance), mi, value));
    var answer = lambda.Compile()();
