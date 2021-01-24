    public static void Error(string playerName, Exception ex, object instance = null)
    {
        ...
        if (instance != null)
        {
            var bindingFlags = BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.NonPublic |
                BindingFlags.Public;
    
            Type classType = instance.GetType();
            if (classType.GetFields(bindingFlags).Length > 1)
            {
                message += DebuggerLine("Plugin Class Variables") + nL;
    
                foreach (var variable in classType.GetFields(bindingFlags))
                {
                    message += DebuggerLine(variable.Name, variable.GetValue(instance).ToString()) + nL;
                }
            }
    
            message += DebuggerLine() + nL;
        }
        ...
    }
