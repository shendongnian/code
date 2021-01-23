    private static void ExecuteLogic(Action action)
    {
        try
        {
            action();
        }
        catch(BussinessException e)
        {
            //save e.info to database
        }
    }
