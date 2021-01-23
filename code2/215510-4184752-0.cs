    // this method is the lambda 
    // (workingSentence, next) => next + " " + workingSentence)
    public string Accumulate(string part, string previousResult)
    {  
        return part + " " + previousResult;
    }
    
    public void Reverse(string original)
    {
      string retval = string.Empty;
      foreach(var part in original.Split(' '))
        retval = Accumulate(part, retval);
      return retval;
    }
