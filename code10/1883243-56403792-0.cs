var results = values2.Permutations(24)
                     .Select(p => String.Join(",", p))
                     .Distinct()
                     .Take(100);
foreach (var permutation in results)
    Console.WriteLine(permutation);
where `Permutations()` is implemented as an extension method. The number 24 here indicates how many items should be in each permutation. It is the `k` in <sub>n</sub>P<sub>k</sub>.
The `Select()` call creates a string string with all the items for the particular permutation.
The `Distinct()` call makes sure that we only end up with unique strings.
The `Take()` call limits the number of strings that we collect.
Here is a naive implementation using recursion to generate the permutations:
public static IEnumerable<T[]> Permutations<T>(this IEnumerable<T> source, int k)
{
    if (k < 0)
        throw new ArgumentOutOfRangeException(nameof(k), "May not be negative");
    var items = source.ToArray();
    if (k > items.Length)
        throw new ArgumentOutOfRangeException(nameof(k), "May not be bigger than the number of items in source");
    var buffer = new ArraySegment<T>(items, 0, k);
    return Permute(0);
    IEnumerable<T[]> Permute(int depth)
    {
        if (depth == k)
        {
            yield return buffer.ToArray();
            yield break;
        }
        for (int i = depth; i < items.Length; i++)
        {
            Swap(depth, i);
            foreach (var permutation in Permute(depth + 1))
                yield return permutation;
            Swap(depth, i);
        }
    }
    void Swap(int a, int b)
    {
        if (a != b)
        {
            T t = items[a];
            items[a] = items[b];
            items[b] = t;
        }
    }
}
I leave it to you to replace the implementation with the algorithm of your choice.
