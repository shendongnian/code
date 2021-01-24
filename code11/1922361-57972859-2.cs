static void Main(string[] args)
{
     var shop_json = new WebClient().DownloadString("https://www.supremenewyork.com/mobile_stock.json");
     var shirt_stock = JsonConvert.DeserializeObject<StockObject>(shop_json);
     Console.WriteLine(shirt_stock);
}
public class StockObject
{
    public ProductsCats Products_and_categories { get; set; }
}
public class ProductsCats
{
    public Details[] Shirts { get; set; }
    public Details[] Bags { get; set; }
    public Details[] Accessories { get; set; }
    public Details[] Pants { get; set; }
    public Details[] Jackets { get; set; }
    public Details[] Skates { get; set; }
    public Details[] Hats { get; set;}
    public Details[] Sweatshirts { get; set;}
    [JsonProperty("Tops/Sweaters")]
    public Details[] TopsSweaters { get;set;}
    public Details[] New { get; set; }
}
public class Details
{
    public string name { get; set; }
    public int id { get; set; }
    public string image_url { get; set; }
    public string image_url_hi { get; set; }
    public int price { get; set; }
    public int sale_price { get; set; }
    public bool new_item { get; set; }
    public int position { get; set; }
    public string category_name { get; set; }
    public int price_euro { get; set; }
    public int sale_price_euro { get; set; }
}
You see what I have done here? 
So your Json data contains a parent node `products_and_categories` and its child node contains an array of `Shirts` which is what you are after?
`StockObject` class contains the `Parent` property called `Products_and_categories` of type object `ProductsCats`. 
`ProductsCats` Object contains the property `Shirts` of type `Details` which is an array and will be used during the `deserialising` process. 
Hope this helps?
