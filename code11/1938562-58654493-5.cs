    static public class IEnumerableHelper
    {
      static public IEnumerable<T> customExtensionMethods<T>(this IEnumerable<T> items, 
                                                             T takeFirst, 
                                                             int skipCount)
      {
        var list1 = items.SkipWhile(item => !item.Equals(takeFirst));
        var list2 = list1.Skip(skipCount + 1).Take(1);
        return list1.Take(1).Concat(list2);
      }
    }
