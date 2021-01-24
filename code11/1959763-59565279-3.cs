cs
public void PrintQuantityForSingleItem(string itemName)
{
	var results = Orders
		.SelectMany(o => o.Items)
		.GroupBy(i => i.Name)
		.Select(g => new { Item = g.Key, Sum = g.Sum(i => i.Quantity) });
	var item = results.FirstOrDefault(r => r.Item.Equals(itemName, StringComparison.OrdinalIgnoreCase));
	Console.WriteLine(itemName + " " + item?.Sum);//shows 24 for item1
}
