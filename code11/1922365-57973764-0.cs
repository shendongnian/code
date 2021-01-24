     static void Main(string[] args)
        {
            string shop_json = new WebClient().DownloadString("https://www.supremenewyork.com/mobile_stock.json");
            JavaScriptSerializer shop_object = new JavaScriptSerializer();
            var shirt_stock = shop_object.Deserialize<NewYarkItems>(shop_json);
            var v = shirt_stock;
        }
    public class NewYarkItems
    {
        public dynamic unique_image_url_prefixes { get; set; }
        public products_and_categories products_And_Categories { get; set; }
        public string release_date { get; set; }
        public string release_week { get; set; }
    }
    public class products_and_categories
    {
        public List<items> Jackets { get; set; }
    }
    public class items
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
