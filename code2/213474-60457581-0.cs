csharp
        /// <summary>
        /// Returns the input string with the first character converted to uppercase
        /// </summary>
        public static string ToUpperFirst(this string s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentException("There is no first letter");
            Span<char> a = stackalloc char[s.Length];
            s.AsSpan(1).CopyTo(a.Slice(1));
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
## Performance
|  Method |      Data |      Mean |     Error |    StdDev |
|-------- |---------- |----------:|----------:|----------:|
|  Carlos |       red | 107.29 ns | 2.2401 ns | 3.9234 ns |
|  Darren |       red |  30.93 ns | 0.9228 ns | 0.8632 ns |
| Marcell |       red |  26.99 ns | 0.3902 ns | 0.3459 ns |
|  Carlos | red house | 106.78 ns | 1.9713 ns | 1.8439 ns |
|  Darren | red house |  32.49 ns | 0.4253 ns | 0.3978 ns |
| Marcell | red house |  27.37 ns | 0.3888 ns | 0.3637 ns |
## Full test code
using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
namespace CorePerformanceTest
{
    public class StringUpperTest
    {
        [Params("red", "red house")]
        public string Data;
        [Benchmark]
        public string Carlos() => Data.Carlos();
        [Benchmark]
        public string Darren() => Data.Darren();
        [Benchmark]
        public string Marcell() => Data.Marcell();
    }
    internal static class StringExtensions
    {
        public static string Carlos(this string input) =>
            input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => input.First().ToString().ToUpper() + input.Substring(1)
            };
        
        public static string Darren(this string s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentException("There is no first letter");
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
        
        public static string Marcell(this string s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentException("There is no first letter");
            Span<char> a = stackalloc char[s.Length];
            s.AsSpan(1).CopyTo(a.Slice(1));
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
    
}
