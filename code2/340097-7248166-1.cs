    public static ActionResult ActionName(RandomParameters param)
    {
        try
        {
            // Do Stuff...
            if (cancel)
                return ActionResult.Failure;
    
            return ActionResult.Success;
        }
        catch (SecurityException ex)
        {
            return ActionResult.Failure;
        }
    }
