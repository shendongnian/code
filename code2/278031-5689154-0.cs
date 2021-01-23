    [WebMethod(MessageName = "MaxInt", Description = "Compare two int values 
    and return the max value", EnableSession = true)]
    public int MaxValue(int a, int b)
    {
       return (a > b ? a : b);
    }
    [WebMethod(MessageName = "MaxFloat", Description = "Compare two float values 
    and return the max value", EnableSession = true)]
    public float MaxValue(float a, float b)
    {
       return (a > b ? a : b);
    }
