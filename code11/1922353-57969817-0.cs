public struct Items
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string Image_url { get; set; }
    public string Image_url_hi { get; set; }
    public int Price { get; set; }
    public int Sale_price { get; set; }
    public bool New_item { get; set; }
    public int Position { get; set; }
    public string Category_name { get; set; }
    public int Price_euro { get; set; }
    public int Sale_price_euro { get; set; }
}
Also please stick to C# naming conventions, you should be able to do this since most JSON parsers are case insensitive by default.
