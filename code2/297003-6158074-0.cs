    private Task<T> myRealWork; 
    private T value;
    // ...
    
    
    public async Task<T> GetTask() 
    {
        value = await TaskEx.WhenAll(myRealWork); 
        return value;
    }
