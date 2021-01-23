    public void ProcessError(string errorResponse)
    {
       // Split string and get error parameters (#, input command, etc.)
    
       throw new Exception(String.Format("Error-{0}: See ...", errorNumber));  // Is this OK? More readable than "ER,84,DM,3L" for example.
    }
