    try
    {
        Stuff1 stf1 = new Stuff1());
        try
        {
            Stuff2 stf2 = new Stuff2();
        }
        finally
        {
            stf2.Dispose();
        }
    }
    finally
    {
        stf1.Dispose();
    }
