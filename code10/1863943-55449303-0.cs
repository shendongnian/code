using System;
using System.Collections.Generic;
using System.Linq;
public static class MyFunkyExtensions
{
    public static IEnumerable<TResult> ZipThree<T1, T2, T3, TResult>(
        this IEnumerable<T1> source,
        IEnumerable<T2> second,
        IEnumerable<T3> third,
        Func<T1, T2, T3, TResult> func)
    {
        using (var e1 = source.GetEnumerator())
        using (var e2 = second.GetEnumerator())
        using (var e3 = third.GetEnumerator())
        {
            while (e1.MoveNext() && e2.MoveNext() && e3.MoveNext())
                yield return func(e1.Current, e2.Current, e3.Current);
        }
    }
}
class MainClass {
  public static void Main (string[] args) {
    var list = new List<List<double>> { new List<double> {1.11,2.11,3.11},  new List<double>  {2.11,3.11,4.11},  new List<double>  {4.11,5.11,6.11} };
    var a = list[0].ZipThree(list[1], list[2], (x, y, z) => (x + y + z) / 3);
    Console.WriteLine(
      string.Join(",",
      a.Select(s => s.ToString())));
  }
}
And it returns
2.44333, 3.443333, 4.44333
