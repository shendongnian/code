List<Task> tasks = new List<Task>();
foreach (var item in items)
{
    tasks.Add(Task.Run(() => 
    {
        var allItemPrices = await MarketAnalysisManager.GetItemPricesFromJsonAsync(item.UniqueName, true);
        if (allItemPrices.FindAll(a => a.City == Locations.GetName(Location.BlackMarket)).Count <= 0)
        {
            await IncreaseBlackMarketProgressBar();
            continue;
        }
        blackMarketSellObjectList.AddRange(await GetBlackMarketSellObjectList(item, quialityList, allItemPrices, outdatedHours, profit, location));
        await IncreaseBlackMarketProgressBar();
    }));
}
await Task.WhenAll(tasks);
