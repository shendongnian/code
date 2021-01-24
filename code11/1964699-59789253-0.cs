    static Dictionary<string, Delegate> networkHooks = new Dictionary<string, Delegate>();
    
    private static void RegisterNetworkMethods(Type type)
    {
        // get the methods of this type that have the NetworkMethodAttribute
        var methods = (from m in type.GetMethods(NonPublic | Instance)
                       where m.GetCustomAttributes(false).OfType<NetworkMethodAttribute>().Count() > 0
                       select m).ToList();
        foreach (var method in methods)
        {
            // get the NetworkMethodAttribute Message variable that was assigned
            var message = method.GetCustomAttribute<NetworkMethodAttribute>().Message;
            // todo: store this instance method in an Action somehow so it can be called later
            networkHooks.Add(message, Delegate.CreateDelegate(typeof(Action<Anything>).GetGenericTypeDefinition().MakeGenericType(method.GetParameters()[0].ParameterType), method));
        }
    }
    
