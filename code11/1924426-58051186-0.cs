    const double PAGE_SIZE = 1000D;
    int pageCount = Convert.ToInt32(Math.Ceiling(totalCount/PAGE_SIZE));
Now, if you want the last n (e.g. 41) items, you start at the last page, which is **pageCount**. Your code has to be changed to this:
public async Task DownloadStockCount (long warehouseId)
{
    double count = await restServices.GetStockTakeAllCountForWarehouse(warehouseId);
    int pageCount = Math.Ceiling(count / 1000);
    var realm = Realm.GetInstance();
    List<StockTakeAllItems> results = new List<StockTakeAllItems>();
    // just to make the intend of the code more concise
    int startNumber = pageCount;
    int endNumber = pageCount;
    results = await restServices.GetStockTakeAllWithPagging(warehouseId, startNumber, endNumber);
    await DisplayAlert("Test", $"Count of items for stock count {count.ToString()}", "OK");
}
`` 
