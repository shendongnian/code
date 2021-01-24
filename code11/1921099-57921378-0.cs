    public async Task<string> Method1()
    {
        string s = "some text";
        method2();
        return await Task.FromResult(s);
    }
