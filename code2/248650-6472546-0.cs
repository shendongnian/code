    [SqlProcedure]
    public static void GetSomething(string value)
    {
        try {
            DoGetSomething(value):
        }
        catch (Exception ex) {
            // error handling
        }
    }
    private static void DoGetSomething(string value)
    {
        // implementation goes here
    }
