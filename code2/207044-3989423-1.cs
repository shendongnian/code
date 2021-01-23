    public static class Extensions
    {
      public static IEnumerable<IEnumerable<T>> JaggedPivot<T>(
        this IEnumerable<IEnumerable<T>> source)
      {
        List<IEnumerator<T>> originalEnumerators = source
          .Select(x => x.GetEnumerator())
          .ToList();
        try
        {
          List<IEnumerator<T>> enumerators = originalEnumerators
            .Where(x => x.MoveNext()).ToList();
          while (enumerators.Any())
          {
            List<T> result = enumerators.Select(x => x.Current).ToList();
            yield return result;
            enumerators = enumerators.Where(x => x.MoveNext()).ToList();
          }
        }
        finally
        {
          originalEnumerators.ForEach(x => x.Dispose());
        }
      } 
    }
    public class TestExtensions
    {
      public void Test1()
      {
        IEnumerable<IEnumerable<int>> myInts = new List<IEnumerable<int>>()
        {
          Enumerable.Range(1, 20).ToList(),
          Enumerable.Range(21, 5).ToList(),
          Enumerable.Range(26, 15).ToList()
        };
        foreach(IEnumerable<int> x in myInts.JaggedPivot().Take(10))
        {
          foreach(int i in x)
          {
            Console.Write("{0} ", i);
          }
          Console.WriteLine();
        }
      }
    }
