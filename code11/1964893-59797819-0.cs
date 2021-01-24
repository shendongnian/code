    public async Task<int> VoidMethod("","","")
    {
       await Task.Run(() => VoidMethod("","",""));
       return 1; 
    }
