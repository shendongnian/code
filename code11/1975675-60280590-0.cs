    public async Task SomeProcess()
    {
        //.. some code    
    
        await Task.WhenAll(method1(), method2(), method3());
    }
