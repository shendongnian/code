    Assembly asm = typeof(Action<>).Assembly;
    Dictionary<int, Type> actions = new Dictionary<int, Type>;
    foreach (Type action in asm.GetTypes())
        if (action.Name == "Action" && action.IsGenericType)
            actions.Add(action.GetGenericArguments().Lenght, action)
