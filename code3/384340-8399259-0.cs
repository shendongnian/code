    // Don't use a void here, use a bool
    public bool SometimesIFail(string text)
    {
        try
        {
             //Anything
             return true;
        }
        catch(Exception)
        {
             //Anything
             return false;
        }
    }
    
....
    foreach (String text in texts)
    {
        if(SometimesIFail(text)) // Evaluates to true for success
        {
            // Do your success matching code
        }
 
        // There doesn't need to be an else condition if you're
        // only passing to the next iteration
    }
