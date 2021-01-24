const string template = "{0,-40} {1,-12} {2,-15} {3,-8}";
var lines = new List<string>();
lines.Add(string.Format(template, "Product Name", "Unit Price", "Quantity", "Total"));
foreach (var item in shoppingCart2)
{
    lines.Add(string.Format(template, item.ProductName,
        Utility.FormatAmount(item.UnitPrice), item.QuantityOrder,
        Utility.FormatAmount(item.TotalAmount)));
    table.AddRow(item.ProductName, Utility.FormatAmount(item.UnitPrice),
        item.QuantityOrder, Utility.FormatAmount(item.TotalAmount));
}
table.Options.EnableCount = false;
table.Write();
File.WriteAllLines(filePath, lines);
