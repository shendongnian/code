 c#
static class MyExtensions
{
   public static T MagicGet<T>(
       this Dictionary<string, object> lookup,
       string key)
   {
       return lookup.TryGetValue(key, out var value)) ? (T)value : default(T);
   }
}
...
var value = lTheDict.MagicGet<int?>("TheKey");
Or without creating an extension, you can simply write your original lookup like this:
      int lTheValue = lTheDict.TryGetValue("TheKey", out object lTheObject) ? (int) lTheObject : default(int);
