    [FunctionName(FunctionName)]
    public async Task<object> Run([ActivityTrigger] DurableActivityContextBase context) 
    {
        MethodFromNugetPackage(context);
    }
