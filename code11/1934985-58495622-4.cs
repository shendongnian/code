var d = new Dictionary<string, string>() {
	  { "First Last", "Some data" },
	  { "Fir La", "Some data 2" } };
while (true)
{
	var term = Console.ReadLine();
    // Case-sensitive flag would control RegexOptions
	var results = d.Where( kvp => Regex.IsMatch(kvp.Key, term, RegexOptions.IgnoreCase)).ToList();
	if (results.Any())
		foreach (var kvp in results)
			Console.WriteLine($"\t{kvp.Key}:{kvp.Value}");
	else
		Console.WriteLine("Not found");
}
fi.*la
        First Last:Some data
        Fir La:Some data 2
fir.*t
        First Last:Some data
## Contains
    // Case-sensitive flag would control `StrinComparison` flag.
	var results = d.Where(
	  kvp => kvp.Key.ToLower().Contains(term.ToLower(), StringComparison.InvariantCultureIgnoreCase))
	  .ToList();
}
Fi
Found First Last:Some data
Found Fir La:Some data 2
First
Found First Last:Some data
Fal
Not found
# B. I want a dictionary search. And FAST
You could use `new Dictionary<string,(string CaseSensitiveKey,T Data)` where keys are always lowercase.
*This will not work if it's possible to have 'Gerardo Grignoli' and 'gerardo grignoli' in the dictionary, but I suspect that this is not the case in your case because if you're asking for lookups on keys, you don't are not after partial matches. This is obviously just an assumption.* 
*If you're after a fast solution for full matches with handling of entries which differ only by case please see other answers with `Dictionary<string, Dictionary<string, TValue>>`.*
public static T LowerCaseKeyWay<T>(Dictionary<string, (string CaseSensitiveKey, T Data)> d, string term, bool isCS)
          => d.TryGetValue(term.ToLower(), out var item)
                  ? !isCS
                        ? item.Data
                        : term == item.CaseSensitiveKey ? item.Data : default
                  : default;
Example of use.
class SO
{
    public int Number { get; set; }
    public int Rep { get; set; }
}
public static void Main(string[] args)
{
  var d = new Dictionary<string,(string CaseSensitiveKey,SO Data)>() {
    { "Gerardo Grignoli".ToLower(), ("Gerardo Grignoli", new SO { Number=97471, Rep=7987} )},
    { "John Wu".ToLower(), ("John Wu", new SO { Number=2791540, Rep=34973})}
  };
  foreach( var searchTerm in new []{ "Gerardo Grignoli",  "Gerardo Grignoli".ToLower()} )
  foreach( var isSearchCaseSensitive in new[]{true,false} ) {
      Console.WriteLine($"{searchTerm}/case-sensitive:{isSearchCaseSensitive}: {Search(d, searchTerm, isSearchCaseSensitive)?.Rep}");
  }
}
Output 
Gerardo Grignoli/case-sensitive:True: 7987
Gerardo Grignoli/case-sensitive:False: 7987
gerardo grignoli/case-sensitive:True: 
gerardo grignoli/case-sensitive:False: 7987
----
# Primitive speed test
## Result
noOfSearches: 1000
  noOfItems: 100
    Lowercase key way:        Elapsed 4ms, count found: 1500
    Linq way                  Elapsed 57ms, count found: 1500
noOfSearches: 1000
  noOfItems: 1000
    Lowercase key way:        Elapsed 3ms, count found: 3000
    Linq way                  Elapsed 454ms, count found: 3000
noOfSearches: 10000
  noOfItems: 100
    Lowercase key way:        Elapsed 11ms, count found: 15000
    Linq way                  Elapsed 447ms, count found: 15000
noOfSearches: 10000
  noOfItems: 1000
    Lowercase key way:        Elapsed 10ms, count found: 15000
    Linq way                  Elapsed 5156ms, count found: 15000
noOfSearches: 100000
  noOfItems: 100
    Lowercase key way:        Elapsed 113ms, count found: 150000
    Linq way                  Elapsed 5059ms, count found: 150000
noOfSearches: 100000
  noOfItems: 1000
    Lowercase key way:        Elapsed 83ms, count found: 150000
    Linq way                  Elapsed 48855ms, count found: 150000
noOfSearches: 1000000
  noOfItems: 100
    Lowercase key way:        Elapsed 1279ms, count found: 1500000
    Linq way                  Elapsed 49558ms, count found: 1500000
noOfSearches: 1000000
  noOfItems: 1000
    Lowercase key way:        Elapsed 961ms, count found: 1500000
(...)
# Test code (I'm happy for this to be ripped apart)
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace ConsoleApp4
{
    class SO
    {
        public int Number { get; set; }
        public int Rep { get; set; }
    }
  class Program
  {
      public static void Main(string[] args)
      {
        // Preload linq
        var _ = new []{"•`_´•"}.FirstOrDefault( k => k == "(O_O)" );
        foreach( int noOfSearches in new []{1000, 10000, 100000, 1000000} ) 
          foreach( int noOfItems in new []{100, 1000} ) 
          {
            var d1 = new Dictionary<string, SO>();
            for(int i = 0; i < noOfItems; i++) {
              d1.Add($"Name {i}", new SO {Number = i, Rep = i *2});
            }
            var d2 = new Dictionary<string, (string CaseSensitiveKey, SO Data)>();
            foreach (var entry in d1)
            {
                d2.Add(entry.Key.ToLower(), (entry.Key, entry.Value));
            }
            
            Console.WriteLine($"noOfSearches: {noOfSearches}");
            Console.WriteLine($"  noOfItems: {noOfItems}");
            Console.Write("    Lowercase key way:".PadRight(30));
            PrimitiveSpeedTest( (term, isCS) => LowerCaseKeyWay(d2, term, isCS), noOfItems, noOfSearches);
            Console.Write("    Linq way".PadRight(30));
            PrimitiveSpeedTest( (term, isCS) => LinqWay(d1, term, isCS), noOfItems, noOfSearches);
          }
      }
      private static void PrimitiveSpeedTest(Func<string, bool, SO> search, int noOfItems, int noOfSearches)
      {
          var count = 0;
          Stopwatch sw = Stopwatch.StartNew();
          for (int i = 0; i < noOfSearches; i++)
          {
            var originalTerm = $"Name {i % (noOfItems*2)}"; // Some found, some not found
              foreach (var term in new[] { originalTerm, originalTerm.ToLower() })
                  foreach (var isCS in new[] { true, false })
                  {
                      var so = search(term, isCS);
                      if (so != null) count++;
                      //Console.WriteLine($"{term}/case-sensitive:{isCS}: {Search(d, term, isCS)?.Rep}");
                  }
          }
          var elapsed = sw.Elapsed;
          Console.WriteLine($"Elapsed {sw.ElapsedMilliseconds}ms, count found: {count} ");
      }
      public static SO LowerCaseKeyWay(Dictionary<string, (string CaseSensitiveKey, SO Data)> d, string term, bool isCS)
        => d.TryGetValue(term.ToLower(), out var item)
                ? !isCS
                      ? item.Data
                      : term == item.CaseSensitiveKey ? item.Data : null
                : null;
      static public T LinqWay<T>(Dictionary<string,T> source, string key, bool caseSensitive)
      {
          //Original: if (caseSensitive) return source[key];
          if(caseSensitive) return source.ContainsKey(key) ? source[key] : default;
          key = source.Keys.FirstOrDefault( k => String.Compare(key, k, StringComparison.CurrentCultureIgnoreCase) == 0);
          //Original: if (key == null) throw new KeyNotFoundException();
          if (key == null) return default;
          return source[key];
      }
  }
}
