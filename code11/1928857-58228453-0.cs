    public async Task<IActionResult> MyAction()
    {
        IEnumerable<object> result = null;
        string fileName;
        switch (type)
        {
            case type1:
                Tuple<string, IEnumerable<object>> tuple;
                tuple = await this.GetAsyncData();
                fileName = tuple.Item1;
                result = tuple.Item2;
                break;
            default:
                throw new Exception();
        }
        await _call.External(result, fileName);
    }
    private async Task<Tuple<string, IEnumerable<object>>> GetAsyncData()
    {
        IEnumerable<object> data = await anotherCall();
        string fileName = "NewFileName";
        var tuple = new Tuple<string, IEnumerable<object>>(fileName, data);
        return tuple;
    }
