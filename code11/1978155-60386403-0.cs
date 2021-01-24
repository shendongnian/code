csharp
foreach (var item in wiznzList)
{
	if (nameList.Any(p => p == item.ProductName)
	{
		wizNzPriceList.Add(item.Price);
	}
	else
	{
		wizNzPriceList.Add("No Product");
	}
}
