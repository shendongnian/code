    static public class EnumerableStringHelper
    {
      static public IEnumerable<string> customExtensionMethods(this IEnumerable<string> list)
      {
        // ...
      }
    }
    static void Test()
    {
      string[] toys = { "car", "bat-mask", "halloween-toys", "marvel-toys", "transformer" };
      var test = toys.customExtensionMethods();
    }
