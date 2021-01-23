    void M()
    {
        var fs = new FileStream(...);
        try
        {
           fs.Write(...);
        }
        finally
        {
           fs.Close();
        }
    }
