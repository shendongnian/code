    void Main()
    {
        var productInfo = new ProductInfo();
        productInfo.ProductName = "Product Name";
    
        var jsonResolver = new PropertyRenameSerializerContractResolver();
        jsonResolver.RenameProperty(typeof(ProductInfo), "prd", "product_name");
    
        var serializerSettings = new JsonSerializerSettings();
        serializerSettings.ContractResolver = jsonResolver;
    
        var json = JsonConvert.SerializeObject(productInfo, serializerSettings);
    
        Console.WriteLine(json);
    }
    
    public class ProductInfo
    {
        [JsonProperty("prd")]
        public string ProductName { get; set; }
    }
    
    public class PropertyRenameSerializerContractResolver : DefaultContractResolver
    {
        private readonly Dictionary<Type, Dictionary<string, string>> _renames;
    
        public PropertyRenameSerializerContractResolver()
        {
            _renames = new Dictionary<Type, Dictionary<string, string>>();
        }
    
        public void RenameProperty(Type type, string propertyName, string newJsonPropertyName)
        {
            if (!_renames.ContainsKey(type))
                _renames[type] = new Dictionary<string, string>();
    
            _renames[type][propertyName] = newJsonPropertyName;
        }
    
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
    
            if (IsRenamed(property.DeclaringType, property.PropertyName, out var newJsonPropertyName))
                property.PropertyName = newJsonPropertyName;
    
            return property;
        }
    
        private bool IsRenamed(Type type, string jsonPropertyName, out string newJsonPropertyName)
        {
            Dictionary<string, string> renames;
    
            if (!_renames.TryGetValue(type, out renames) || !renames.TryGetValue(jsonPropertyName, out newJsonPropertyName))
            {
                newJsonPropertyName = null;
                return false;
            }
    
            return true;
        }
    }
