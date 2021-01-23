    private void Func3()
    {
        // Will not execute the method body
        Func2();
    }
    private void Func1()
    {
        // Will execute the method body
        Func2();
    }
    private void Func2()
    {
        var callingMethodName = new StackFrame(1, true).GetMethod().Name;
        if (string.Equals(callingMethodName, "Func1"))
        {
            // Execute your method's code....
        }
    }
