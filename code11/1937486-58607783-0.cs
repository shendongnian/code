public static string[] Compare (string[] a, string[] b )
{
     var inAOnly = a.Where( aa => !b.Contains(aa));
     var inBOnly = b.Where( bb => !a.Contains(bb));
     return inAOnly.Union(inBOnly).ToArray();
}
# Test
## Code 
public static void Main(string[] args)
{
    List<string[]> list = new List<string[]>();
     string[] a = {"some", "random", "string"};
     string[] b = {"some", "other", "random", "string"};
     list.Add(a);
     list.Add(b);
     string[] differences = Compare(a,b);
    foreach( var diff in differences ) Console.WriteLine(diff);
}
public static string[] Compare (string[] a, string[] b )
{
     var inAOnly = a.Where( aa => !b.Contains(aa));
     var inBOnly = b.Where( bb => !a.Contains(bb));
     return inAOnly.Union(inBOnly).ToArray();
}
## Ouput
// .NETCoreApp,Version=v3.0
other
