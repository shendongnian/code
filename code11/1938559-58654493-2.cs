    static public class IEnumerableHelper
    {
      static public IEnumerable<T> customExtensionMethods<T>(this IEnumerable<T> list, 
                                                             T takeFirst, 
                                                             int skipCount)
      {
        var result1 = list.SkipWhile(item => !item.Equals(takeFirst));
        var result2 = list.Skip(skipCount + 1).Take(1);
        return result1.Take(1).Concat(result2);
      }
    }
    static void Test()
    {
      string[] toys = { "car", "bat-mask", "halloween-toys", "marvel-toys", "transformer" };
      var test = toys.customExtensionMethods("car", 1);
      foreach ( var v in test )
        Console.WriteLine(v);
    }
