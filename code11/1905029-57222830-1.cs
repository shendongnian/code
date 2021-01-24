lang-csharp
public interface IHaveAnId
{
   [MaxLength(5)]
   string Id { get; set; }
}
public class SimplePerson : IHaveAnId
{
   [MaxLength(10)]
   public string Id { get; set; }
   [MaxLength(100)]
   public string DisplayName { get; set; }
}
public void Main()
{
   IHaveAnId s = new SimplePerson();
   s.TruncateToMaxLength(); 
}
Then the call to `s.TruncateToMaxLength` will operate on all the properties of `SimplePerson` and use the `MaxLength` attribute on that `class`' properties.
As an aside, I don't know what your performance requirements are, but you can speed up `TruncateToMaxLength<TClass>`. It'll never be as fast as your `ManualMaxLength` (at the very least I'm not clever enough to get something that fast with reflection), but you can make some gains over what you have now by caching the `PropertyInfo` instances and the `MaxLength` value.
lang-csharp
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
public static class Extensions
{
   public static void TruncateToMaxLengthCached<TClass>(this TClass input)
   {
      var type = typeof(TClass);
      var props = _cache.GetOrAdd(type, t =>
      {
         return new Lazy<IReadOnlyCollection<MaxLengthData>>(() => BuildData(input));
      }).Value;
      foreach (var data in props)
      {
         var value = data.Property.GetValue(input)?.ToString();
         if (value?.Length > data.MaxLength)
         {
            data.Property.SetValue(input, value.Substring(0, data.MaxLength));
         }
      }
   }
   private static IReadOnlyCollection<MaxLengthData> BuildData<TClass>(TClass input)
   {
      Type type = typeof(TClass);
      var result = new List<MaxLengthData>();
      foreach (var prop in type.GetProperties())
      {
         var maxLengthAttribute = prop.GetCustomAttribute<MaxLengthAttribute>();
         if (null != maxLengthAttribute)
         {
            result.Add(new MaxLengthData
            {
               MaxLength = maxLengthAttribute.Length,
               Property = prop,
               TargetType = type
            });
         }
      }
      return result;
   }
   private static ConcurrentDictionary<Type, Lazy<IReadOnlyCollection<MaxLengthData>>> _cache =
      new ConcurrentDictionary<Type, Lazy<IReadOnlyCollection<MaxLengthData>>>();
   private class MaxLengthData
   {
      public Type TargetType { get; set; }
      public PropertyInfo Property { get; set; }
      public int MaxLength { get; set; }
   }
}
And the BenchmarkDotNet results:
|           Method |             Id |                  Name |          Mean |       Error |      StdDev | Rank |
|----------------- |--------------- |---------------------- |--------------:|------------:|------------:|-----:|
|   ManualTruncate | 09123456789093 |          John Johnson |     28.103 ns |   0.6188 ns |   0.8046 ns |    2 |
| OriginalTruncate | 09123456789093 |          John Johnson | 17,953.005 ns | 356.7870 ns | 534.0220 ns |    8 |
|   CachedTruncate | 09123456789093 |          John Johnson |    697.548 ns |  13.6592 ns |  13.4152 ns |    6 |
|   ManualTruncate | 09123456789093 |  Mr. J(...), Esq [98] |     59.177 ns |   1.2251 ns |   1.5494 ns |    4 |
| OriginalTruncate | 09123456789093 |  Mr. J(...), Esq [98] | 18,333.251 ns | 365.0699 ns | 461.6966 ns |    8 |
|   CachedTruncate | 09123456789093 |  Mr. J(...), Esq [98] |    995.924 ns |  19.9356 ns |  23.7319 ns |    7 |
|   ManualTruncate | 09123456789093 | Mr. J(...)hnson [111] |     58.787 ns |   0.4812 ns |   0.4501 ns |    4 |
| OriginalTruncate | 09123456789093 | Mr. J(...)hnson [111] | 18,032.030 ns | 220.0009 ns | 195.0251 ns |    8 |
|   CachedTruncate | 09123456789093 | Mr. J(...)hnson [111] |    977.168 ns |  19.2770 ns |  27.6465 ns |    7 |
|   ManualTruncate |              1 |          John Johnson |      6.800 ns |   0.2039 ns |   0.2651 ns |    1 |
| OriginalTruncate |              1 |          John Johnson | 18,173.803 ns | 192.1153 ns | 170.3052 ns |    8 |
|   CachedTruncate |              1 |          John Johnson |    410.136 ns |   3.8655 ns |   3.6158 ns |    5 |
|   ManualTruncate |              1 |  Mr. J(...), Esq [98] |     34.886 ns |   0.7203 ns |   0.6385 ns |    3 |
| OriginalTruncate |              1 |  Mr. J(...), Esq [98] | 18,013.630 ns | 327.2057 ns | 306.0684 ns |    8 |
|   CachedTruncate |              1 |  Mr. J(...), Esq [98] |    684.351 ns |  12.0877 ns |  11.3069 ns |    6 |
|   ManualTruncate |              1 | Mr. J(...)hnson [111] |     34.285 ns |   0.6136 ns |   0.5124 ns |    3 |
| OriginalTruncate |              1 | Mr. J(...)hnson [111] | 17,926.434 ns | 184.0216 ns | 172.1340 ns |    8 |
|   CachedTruncate |              1 | Mr. J(...)hnson [111] |    685.590 ns |   9.6743 ns |   9.0493 ns |    6 |
