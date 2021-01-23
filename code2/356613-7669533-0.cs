    public void myMethod(out anythingObject)
    {
        try
        {
            anything = new anythingObject(stuff goes here); 
        }
        catch
        {
            Environment.Exit(1); //or a function which always either calls Environment.Exit or throws an exception
        }
    }
