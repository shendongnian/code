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
# Test
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
## Output
// .NETCoreApp,Version=v3.0
some
random
