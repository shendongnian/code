    void RunStoredProc1(object input1)
    {
        var args = new Dictionary<string, object>()
                   {
                       { "input1", input1 }
                   };
    
        try
        {
            RunStoredProc("storedProc1", args);
        }
        catch (Exception ex)
        {
            // Handle exception properly
        }
    }
