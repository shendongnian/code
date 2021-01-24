private static IEnumerable<(string,string[])> Compare(List<(string Name,string[] Words)> lists)
{
    for(int i = 0; i < lists.Count - 1; i++) {
        var a = lists[i];
        var b = lists[i + 1];
        yield return ($"{a.Name}<->{b.Name}", a.Words.Intersect(b.Words).ToArray());
     }
}
## Test
### Code 
List<(string, string[])> list = new List<(string, string[])>();
string[] a = {"some", "random", "string"};
string[] b = {"some", "other", "random", "string"};
string[] c = {"some", "other2", "random", "string2"};
list.Add(("a", a));
list.Add(("b", b));
list.Add(("c", c));
foreach( var pair in Compare(list) )
        Console.WriteLine($"{pair.Item1}: {string.Join(", ", pair.Item2)}");
### Output
// .NETCoreApp,Version=v3.0
a<->b: some, random, string
b<->c: some, random
# 2. Find words in all arrays
private static string[] InAll(List<string[]> lists)
{
    var inAll = new List<string>();
    foreach(var list in lists ) {
        foreach(var word in list) {
            if(lists.All(l => l.Contains(word))) {
                inAll.Add(word);
            }
        }
    }
    return inAll.Distinct().ToArray();
}
## Test
### Code
public static void Main(string[] args)
{
    List<string[]> list = new List<string[]>();
    string[] a = {"some", "random", "string"};
    string[] b = {"some", "other", "random", "string"};
    string[] c = {"some", "other2", "random", "string2"};
    list.Add(a);
    list.Add(b);
    list.Add(c);
    foreach( var inAll in InAll(list) ) Console.WriteLine(inAll);
}
### Output
// .NETCoreApp,Version=v3.0
some
random
