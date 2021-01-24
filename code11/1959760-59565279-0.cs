cs
public void PrintQuantityForSingleItem(string itemName)
{
	var result = Orders
		.SelectMany(_ => _.Items)
		.GroupBy(_ => _.Name)
		.Select(_ => new { Item = _.Key, Sum = _.Sum(i => i.Quantity) });
	var item = result.FirstOrDefault(_ => _.Item.Equals(itemName));
	Console.WriteLine(itemName + " " + item?.Sum);//for example: shows 24 for item1
}
