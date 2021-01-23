    [Pure]
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    public static T[] Empty<T>()
    {
        Contract.Ensures(Contract.Result<T[]>() != null);
        Contract.Ensures(Contract.Result<T[]>().Length == 0);
        Contract.EndContractBlock();
        
        return EmptyArray<T>.Value;
    }
