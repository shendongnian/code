    public async Task<T> GetTask() 
    {
        value = await TaskEx.RunEx(() => ComputeRealValueAndReturnIt()); 
        return value;
    }
