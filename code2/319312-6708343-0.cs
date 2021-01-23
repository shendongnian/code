    StackTrace stackTrace = new StackTrace();
    if (stackTrace.GetFrame(1).GetMethod().DeclaringType.Name == "A")
    {
        // Class A called us
    }
