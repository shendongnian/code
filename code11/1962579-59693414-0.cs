csharp
using System.Linq;
using System.Collections.Generic;
...
private static IEnumerable<int> Solve(int[] numbers, int k) {
    return numbers
        .GroupBy(x => x)
        .OrderByDescending(g => g.Count())
        .Select(g => g.Key)
        .Take(k);
}
Then you can call:
csharp
var numbers = new []{1,2,2,9,1,2,5,5,5,5,2};
var k = 3;
var result = Solve(numbers, k);
foreach (int n in result)
    Console.WriteLine(n);
