    public static void Error(string playerName, Exception ex, object target = null)
    {
        ...
        if (target != null)
        {
            var bindingFlags = BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.NonPublic |
                BindingFlags.Public;
    
            Type classType = target.GetType();
            if (classType.GetFields(bindingFlags).Length > 1)
            {
                message += DebuggerLine("Plugin Class Variables") + nL;
    
                foreach (var variable in classType.GetFields(bindingFlags))
                {
                    message += DebuggerLine(variable.Name, variable.GetValue(target).ToString()) + nL;
                }
            }
    
            message += DebuggerLine() + nL;
        }
        ...
    }
