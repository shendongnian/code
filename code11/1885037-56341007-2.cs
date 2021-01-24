List<Task> tasks = new List<Task>();
foreach (var item in items)
{
    tasks.Add(Task.Run(async () => 
    {
        var allItemPrices = await MarketAnalysisManager.GetItemPricesFromJsonAsync(item.UniqueName, true);
        if (allItemPrices.FindAll(a => a.City == Locations.GetName(Location.BlackMarket)).Count <= 0)
        {
            await IncreaseBlackMarketProgressBar();
            return;
        }
        blackMarketSellObjectList.AddRange(await GetBlackMarketSellObjectList(item, quialityList, allItemPrices, outdatedHours, profit, location));
        await IncreaseBlackMarketProgressBar();
    }));
}
await Task.WhenAll(tasks);
  
Note: There is now a return instead of a continue since this is an annonymous function and you just have to end the function there instead of continuing with the foreach. 
