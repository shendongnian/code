    public static ICodeHandler GetCodeHandlerFor(string code)
    {
        if (DatabaseCheck1(code)
        {
            return new FirstCodeHandlerClass(code);            
        }
        else if (LookForSomethingElseInDB(code)
        {
            return new SecondCodeHandlerClass(code);            
        }
        else
        {
            return new ThirdCodeHandlerClass(code);
        }
    }
