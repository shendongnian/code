    public static class ExtensionsMethod
    {
        public static bool ObjectsAreEqual(this IEnumerable<ProductInventoryInfo> items, ProductInventoryInfo obj2)
        {
            return items.Any(productInventoryInfo => ObjectsAreEqual<ProductInventoryInfo>(productInventoryInfo, obj2));
        }
        private static bool ObjectsAreEqual<T>(T obj1, T obj2)
        {
            return JsonConvert.SerializeObject(obj1) == JsonConvert.SerializeObject(obj2);//convert object to json by Newtonsoft.Json and compare that
        }
    }
