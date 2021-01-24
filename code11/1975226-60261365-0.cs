csharp
var result = fullList
    .Select(original =>
       // We want the original sublist...
       original
           // concatenated with...
           .Concat(
           // ... any comboList element
           comboList
               // which is completely distinct from "original"
               .Where(cl => !original.Intersect(cl).Any())
               // ... flattening all such comboLists
               .SelectMany(cl => cl))
           .ToList())
    .ToList();
Here's a complete example:
csharp
using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        var fullList = new[]
        {
            new[] { 1, 2, 3 },
            new[] { 2, 5, 6 },
            new[] { 7, 8, 9 }
        };
        
        var comboList = new[]
        {
            new[] { 2, 5 },
            new[] { 8, 9 }
        };
        
        var result = MergeCombinations(fullList, comboList);
        foreach (var item in result)
        {
            Console.WriteLine(string.Join(", ", item));
        }
    }
    
    static List<List<T>> MergeCombinations<T>(
        IEnumerable<IEnumerable<T>> fullList,
        IEnumerable<IEnumerable<T>> comboList)
    {
        var result = fullList
            .Select(original =>
                // We want the original sublist...
                original
                    // concatenated with...
                    .Concat(
                    // ... any comboList element
                       comboList
                           // which is completely distinct from "original"
                           .Where(cl => !original.Intersect(cl).Any())
                           // ... flattening all such comboLists
                          .SelectMany(cl => cl))
                   .ToList())
             .ToList();
        return result;
    }                                           
}
