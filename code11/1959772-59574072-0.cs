    public static async Task<List<GeoJSON>> GetAddressesInParallel(List<GeoJSON> geos)
    {
        var block = new ActionBlock<GeoJSON>(async item =>
        {
            await SendPOSTAsync(item);
        }, new ExecutionDataflowBlockOptions()
        {
            MaxDegreeOfParallelism = 1000
        });
        foreach (var item in geos)
        {
            await block.SendAsync(item);
        }
        block.Complete();
        await block.Completion;
        return geos;
    }
