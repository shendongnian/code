public class StockItem
{
	public string StockName { get; set; }
	public int StockCount { get; set; }
}
You can then add all the stock items to a list.
List<StockItem> allItems = new List<StockItem>();
string[] allFiles = Directory.GetFiles(path); 
foreach(var file in allFiles)
{
	// open the file - you need to read the file here - and create thisFile
	foreach(string line in thisFile)
	{
		string[] thisItem = line.Split(' ');
		allItems.Add(new StockItem() {StockName = thisItem[1], StockCount = int.Parse(thisItem[2])});
	}
	
}
Run a `linq` query to get the sum of each item.
Dictionary<string, int> itemCounts = allItems.GroupBy(i => i.StockName)
									.Select(m => new
									{
										Name = m.First().StockName,
										Total = m.Sum(x => x.StockCount)
									}).ToDictionary(d => d.Name, d => d.Total);
This creates a dictionary of the item name with its total stock count.
And finally, query the dictionary to find its maximum stock count and all items which have this value. 
int maxValue = itemCounts.Max(x => x.Value);
List<string> itemsWithMaxValue = itemCounts.Where(x => x.Value == maxValue)
                                           .Select(x => x.Key).ToList();
