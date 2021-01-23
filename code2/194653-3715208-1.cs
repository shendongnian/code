    int Test()
    {
        int result = 4;
        try
        {
            return result;
        }
        finally
        {
            // Attempt to subvert the result
            result = 1;
        }
    }
