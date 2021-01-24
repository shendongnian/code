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
	// open the file as thisFile
	foreach(string line in thisFile)
	{
		string[] thisItem = line.Split(' ');
		allItems.Add(new StockItem() {StockName = thisItem[1], StockCount = int.Parse(thisItem[2])});
	}
	
}
And finally, run a `linq` query to get the max value and it's name.
... comng in a minute, I've just been called to supper ...
