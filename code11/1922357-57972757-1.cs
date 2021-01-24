    public class BaseItem
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
    public class Shirt : BaseItem { }
    public class Bag : BaseItem { }
    public class Accessory : BaseItem { }
    public class Pant : BaseItem { }
    public class Jacket : BaseItem { }
    public class Skate : BaseItem { }
    public class Hat : BaseItem { }
    public class Sweatshirt : BaseItem { }
    public class TopsSweater : BaseItem { }
    public class New : BaseItem { }
    public class RootObject
    {
        public List<object> Unique_image_url_prefixes { get; set; }
        public ProductsAndCategories Products_and_categories { get; set; }
        public string Release_date { get; set; }
        public string Release_week { get; set; }
    }
    public class ProductsAndCategories
    {
        public List<Shirt> Shirts { get; set; }
        public List<Bag> Bags { get; set; }
        public List<Accessory> Accessories { get; set; }
        public List<Pant> Pants { get; set; }
        public List<Jacket> Jackets { get; set; }
        public List<Skate> Skate { get; set; }
        public List<Hat> Hats { get; set; }
        public List<Sweatshirt> Sweatshirts { get; set; }
        [JsonProperty("Tops/Sweaters")]
        public List<TopsSweater> TopsSweaters { get; set; }
        public List<New> New { get; set; }
    }
