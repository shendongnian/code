csharp
using Linq;
using System.Collections.Generic;
public static class IEnumerableExtensions
{
    // Extension method for IEnumerable
    public static IEnumerable<int> AllIndexesOf<T>(this IEnumerable<T> list, T searchValue)
    {
        for (int i = 0; i < list.Count(); i++)
        {
            yield return i;
        }
    }
}
Then find the max value in the array using LINQ and call the method:
csharp
using Linq; // include this at the top of your file, if not already present.
// ...
int[] array = new int[] {1, 3, 2, 3};
IEnumerable<int> matchingIndexes = array.AllIndexesOf(array.Max());
// Convert to array if you need one
int[] matchingIndexesArr = matchingIndexes.ToArray();
You can find more information about extension methods [in the docs][1].
  [1]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
