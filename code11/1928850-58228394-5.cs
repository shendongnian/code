    public async Task<IActionResult> MyAction()
    {
        switch (type)
        {
            case type1:
                var (fileName, result) = await this.GetAsyncData();
                break;
    
            default:
                throw new Exception();
        }
    
        await _call.External(result, fileName);
    }
