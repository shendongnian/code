    StackTrace stack = new StackTrace();
    StackFrame[] frames = stack.GetFrames();
    foreach (StackFrame frame in frames)
    {
        Type callingMethodClassType = frame.GetMethod().DeclaringType;
        if (callingMethodClassType.IsGenericType)
        {
            // BUG HERE in getting generic arguments of the class in stack
            Type genericType = callingMethodClassType.GetGenericArguments()[0];
            if (genericType.GetFullName.Equals(entityType.GetFullName))
            {
                wasAlready = true;
                break;
            }
        }
    }
    private static String GetFullName<T>(this T type) 
    {
        return typeof(T).FullName;
    }
