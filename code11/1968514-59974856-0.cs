C#
public static List<string> ListExcept(this List<string> l1, List<string> l2)
{
    IEnumerable<HashSet<string>> listOfHashes = l1.Select(x => x.Split(',').ToHashSet());
    IEnumerable<HashSet<string>> finalLists = listOfHashes.Where(hash => l2.All(x => !hash.Contains(x)));
    IEnumerable<string> joined = finalLists.Select(x => x.Aggregate("", (s, s1) => s + s1 + ",")[..^1]);
    return joined.ToList();
}
Obviously you can join the calls, I split them and specified the types explicitly to make it clearer.  
 
And then you can just call it as:
C#
l2.ListExcept(l1);
