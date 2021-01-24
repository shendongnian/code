cs
var lineItemDetails = xdoc.Root?.Descendants("Item");
foreach (var lineItemDetail in lineItemDetails?.Nodes().OfType<XElement>())
{
	var Devtm = lineItemDetail?.Attribute("PL")?.Value;
	Console.WriteLine(Devtm);
}
It prints `SP` and `RV`.
If you want to use access using index, without loop, this can help
cs
var lineItemDetails = xdoc.Root?.DescendantsAndSelf("Item").FirstOrDefault();
var nodes = lineItemDetails?.DescendantNodes().OfType<XElement>().ToList();
Console.WriteLine(nodes?[0]?.Attribute("PL")?.Value);
Console.WriteLine(nodes?[1]?.Attribute("PL")?.Value);
