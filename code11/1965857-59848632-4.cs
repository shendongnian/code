    private async Task<RequestResult<Response>> MyMethodAsync(int i)
    {
         // Some code
    }
    
    public async Task<T> TryExecuteWithCertificateValidationAsync<T>(int, Func<Task<T>> operation) // Add int as second generic argument
    {
        T actualResult = await operation(1); // Can now be called with an integer
        return actualResult;
    }
