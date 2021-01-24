    public Task<bool> MyFuncAsync()
    {
       return true;
    } 
    public bool MyFunc()
    {
       return MyFuncAsync().Result;
    }
