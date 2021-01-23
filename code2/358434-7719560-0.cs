    if(isError)
          throw MakeMeAnException(response);  
    ...
    }
    public Exception MakeMeAnException(string errorResponse)
    {
       // Split string and get error parameters (#, input command, etc.)
       return new Exception(String.Format("Error-{0}: See ...", errorNumber)); 
    }
