static void Main(string[] args)
{
     var shop_json = new WebClient().DownloadString("https://www.supremenewyork.com/mobile_stock.json");
     var shirt_stock = JsonConvert.DeserializeObject<RootObject>(shop_json);
     Console.WriteLine(shirt_stock);
}
public class RootObject
{
    public ProductsCats Products_and_categories { get; set; }
}
public class ProductsCats
{
    public Shirts[] Shirts { get; set; }
}
public class Shirts
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
