    public bool TestMethod()
    {
        try
        {
            if (some_condition)
            { 
                //some random code
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
    }
