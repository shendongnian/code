    public void myMethod(out int i)
    {
        try
        {
           i = anythingHere();
        }
        catch
        {
            Environment.Exit(1);
        }
    }
