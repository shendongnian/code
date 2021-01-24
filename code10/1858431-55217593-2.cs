public static class SerializerExtensions {
   public static T FromJson<T>(this T obj, string json) where T:AJsonSerializer  {
       JsonConvert.PopulateObject(json, obj);
       return obj;
   }
}
This way you won't need to implement passing of generic type throughout the inheritance chain. 
But you need to initialize the value to access, so it would be:
var user = new User();
user.FromJson(jsonSTring);
or
var user = SerializerExtensions.FromJson(new User(), jsonString);
It's your decision what fits your use case better.
