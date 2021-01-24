    Type asyncStateMachine = 
        typeof(TestClass)
        .GetNestedTypes(BindingFlags.NonPublic)
        .FirstOrDefault(
            t => t.GetCustomAttribute<CompilerGeneratedAttribute>() != null 
            && typeof(IAsyncStateMachine).IsAssignableFrom(t));
    MethodInfo method = asyncStateMachine.GetMethod(
        nameof(IAsyncStateMachine.MoveNext),
        BindingFlags.NonPublic | BindingFlags.Instance);
    List<MethodInfo> calls = method.GetInstructions()
        .Select(x => x.Operand as MethodInfo)
        .Where(x => x != null)
        .ToList();
    // etc
