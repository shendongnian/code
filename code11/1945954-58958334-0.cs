public class Products
{
    public List<YourProduct> ArrayProperty{ get; set; }
}
public class YourProduct
{
    public string Id { get; set; }
    public string Index { get; set; }
    public float Stock { get; set; }
    public string Name { get; set; }
}
public class YourSettings
{
    public List<ProductSettings> ArrayProperty { get; set; }
}
public class ProductSettings
{
    public string Id { get; set; }
    public bool IsCool { get; set; }
    public bool WouldIBuyIt { get; set; }
}
2) install JSON.net using nuget package manager, 
3) load your JSON from file to string (if your json file will be very big, better use JsonReader or other object to work with JSON. You always can read documentation for that) 4) deserialize your json to object with this method:
string reader = MethodToReadJsonFromFile();
JsonSerializer serializer = new JsonSerializer();
var result = serializer.Deserialize<Products>(reader);
6) use it to get two object list and then you can use any proper way to merge them in any way you need (for example you can use LINQ for it, i guess) 
7) And if you need JSON as a result, don't forget to serialize your result object to json string
More about serialization/deserialization: [Json .net introduction][1]
  [1]: https://www.newtonsoft.com/json/help/html/Introduction.htm
