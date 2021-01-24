    public static async Task Main()
    {
        // Configurations ....
        var data = new Data();
        var objects = await data.GetObjects();
        var tasks = objects.Select(o => CustomAsyncMethod(o.Id, data)).ToArray();
        await Tasks.WhenAll(tasks);
    }
