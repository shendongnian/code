    private async Task<TResult> ProcessInputAsync(...)
    {
        return await Task.Run( () => LengthyProcess(...)
    }
    private TResult LengthyProcess(...)
    {
        // this is the time consuming process.
        // it is called by a non-ui thread
        // the ui keeps responsive
        TResult x = ...
        return x;
     }
