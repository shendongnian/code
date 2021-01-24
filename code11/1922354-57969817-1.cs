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
Some more info: A class doesnt really has a proper default constructor if you dont define one, where as a struct always has a default constructor, so when the JSON parser wants to init your class it cant because a default constructor isnt definded.
