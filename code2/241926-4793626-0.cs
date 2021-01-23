    bool Enable()
    {
        try
        {
            GetStatus(ref status);
            // do stuff
                    
            GetStatus(ref status);
            // do more stuff
    
            GetStatus(ref status);
            // do even more stuff
    
            // 6 more times the above
            return true;
        }
        catch (Exception ex)
        {
            Trace.WriteLine("Error"); 
            return false;
        }
    }
