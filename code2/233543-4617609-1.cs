    void SetupAndCleanup( Action<int> methodCode )
    {
        // Setup code here
        int x = 1;
    
        try
        {
            methodCode(x);
        }
        finally
        {
            // cleanup code here
            x = 0;
        }
    }
