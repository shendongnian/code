`
public static void Main()
{
    List<int> list1 = new List<int> { 1, 2, 3, 4, 5, 6 };
    List<int> list2 = new List<int> { 1, 2, 3 };
    List<int> list3 = new List<int> { 1, 2 };
    var commons = GetCommonItems(list1, list2, list3); // pass the lists here
    Console.WriteLine("Common integers:");
    foreach (var c in commons)
        Console.WriteLine(c);
}
static IEnumerable<T> GetCommonItems<T>(params IEnumerable<T>[] lists)
{
    return lists.Skip(1).Aggregate(
        new HashSet<T>(lists.First()),
        (hs, lst) =>
        {
            hs.IntersectWith(lst);
            return hs;
        }
    );
}
`
Alternate solution using a list of lists:
`
public static void Main()
{
    List<int> list1 = new List<int> { 1, 2, 3, 4, 5, 6 };
    List<int> list2 = new List<int> { 1, 2, 3 };
    List<int> list3 = new List<int> { 1, 2 };
    var lists = new List<List<int>> { list1, list2, list3 };
    var commons = GetCommonItems(lists); // pass the lists here
    Console.WriteLine("Common integers:");
    foreach (var c in commons)
        Console.WriteLine(c);
}
static IEnumerable<T> GetCommonItems<T>(IEnumerable<T>[] lists)
{
    return lists.Skip(1).Aggregate(
        new HashSet<T>(lists.First()),
        (hs, lst) =>
        {
            hs.IntersectWith(lst);
            return hs;
        }
    );
}
`
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/params
