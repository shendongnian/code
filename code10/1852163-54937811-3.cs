    public async Task<List<string>> GetList()
    {
        // now we have a reason to be async (barely)
        await Task.Delay(1000);
        List<string> toReturn = new List<string>();
        toReturn.Add("hello");
        toReturn.Add("world");
        return toReturn;
    }
