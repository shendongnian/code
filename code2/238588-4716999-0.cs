    [OperationContract]
    public double GetCounter(string name)
    {
         return Counters[name];
    }
    [OperationContract]
    public void SetCounter(string name, double value)
    {
         Counters[name] = value;
    }
