    public int IncrementByRandomAmount(int input)
    {
        // We can't do anything if we're given int.MaxValue
        Contract.Requires(input < int.MaxValue);
        Contract.Ensures(Contract.Result<int>() > input);
        // Do stuff here to compute output
        return output;
    }
