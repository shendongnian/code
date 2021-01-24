    static public class EnumerableStringHelper
    {
      static public List<string> customExtensionMethods(this IEnumerable<string> array)
      {
        var result = new List<string>();
        // ...
        return result;
      }
    }
    static void Test()
    {
      string[] toys = { "car", "bat-mask", "halloween-toys", "marvel-toys", "transformer" };
      var test = toys.customExtensionMethods();
    }
