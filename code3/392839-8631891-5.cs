    string xml = @"<ProductTable>
    <ProductName>Chair</ProductName>
    <Price>29.5</Price>
    </ProductTable>";
    XDocument x = XDocument.Parse(xml);
    var tables = x.Descendants("ProductTable");
    Dictionary<string,string> products = new Dictionary<string, string>();
    foreach (var productTable in tables)
    {
        string name = productTable.Element("ProductName").Value;
        string price = productTable.Element("Price").Value;
        products.Add(name, price);
    }
