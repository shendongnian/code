public static class SerializerExtensions {
   public static void FromJson<T>(this T obj, string json) where T:AJsonSerializer  {
       obj = JsonConvert.DeserializeObject<T>(json);
   }
}
This way you won't need to implement passing of generic type throughout the inheritance chain. 
But you need to initialize the value to access, so it would be:
var user = new User();
user.FromJson(jsonSTring);
