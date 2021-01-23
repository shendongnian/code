    public void MyMethod(params object[] parameters)
    {
        if (parameters == null || parameters.Length == 0)
            throw new ArgumentException("No parameters specified.");
        if (parameters.Length > 1)
            throw new ArgumentException("Too many parameters specified.");
        if (parameters[0] is int)
            IntMethod((int) parameters[0]);
        else if (parameters[0] is string)
            StringMethod((string) parameters[0]);
        else
            throw new ArgumentException("Unsupported parameter type.");
    }
