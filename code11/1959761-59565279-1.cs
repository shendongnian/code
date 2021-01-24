cs
public void PrintQuantityForSingleItem(string itemName)
{
	var results = Orders
		.SelectMany(o => o.Items)
		.GroupBy(i => i.Name)
		.Select(g => new { Item = g.Key, Sum = g.Sum(i => i.Quantity) });
	var item = results.FirstOrDefault(r => r.Item.Equals(itemName));
	Console.WriteLine(itemName + " " + item?.Sum);//for example: shows 24 for item1
}
