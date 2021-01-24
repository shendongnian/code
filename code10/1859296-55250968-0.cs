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
