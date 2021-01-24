    public async Task<IActionResult> MyAction()
    {
        List<object> result = new List<object>();  //This is a list now
        string fileName;
    
        switch (type)
        {
            case type1:
                fileName = await this.GetAsyncData(result);
                break;
    
            default:
                throw new Exception();
        }
    
        await _call.External(result, fileName);
    }
    
    private async Task<string> GetAsyncData(IEnumerable<object> result)
    {
        result.AddRange( await anotherCall() );   //Add the result of anotherCall() to result
        return "NewFileName";
    }
