    public void SetupMock()
    {
        Random myRandomizer = new Random();
        var contractRepo = new SIContractRepository();
        contractRepo.GetValueAndIncrementCounterRef = GetValueAndIncrementMock;
    }
    
    public long GetValueAndIncrementMock(ref Counter counter)
    {
        return Int64.Parse(myRandomizer.Next().ToString())
    }
