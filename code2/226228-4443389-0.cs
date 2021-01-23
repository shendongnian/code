    var method = typeof(Foo)
                     .GetMethods()
                     .Where(x => x.Name == "Bar")
                     .Where(x => x.IsGenericMethod)
                     .Where(x => x.GetGenericArguments().Length == 1)
                     .Where(x => x.GetParameters().Length == 1)
                     .Where(x => 
                         x.GetParameters()[0].ParameterType == 
                         typeof(Action<>).MakeGenericType(x.GetGenericArguments()[0])
                     )
                     .Single();
                                    
     method = method.MakeGenericMethod(new Type[] { typeof(int) });
    
     Foo foo = new Foo();
     method.Invoke(foo, new Func<int>[] { () => return 42; });
