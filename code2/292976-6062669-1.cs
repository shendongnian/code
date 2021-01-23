    Type1 x = new Type1();
    try
    {
        // a
        Type2 y  = new Type2();
        try
        {
            // b
        }
        finally
        {
            y.Dispose();
        }
        // c
    }
    finally
    {
        x.Dispose();
    }
