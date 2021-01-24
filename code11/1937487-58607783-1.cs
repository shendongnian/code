public static string[] GetDifferences (string[] a, string[] b )
{
     var inAOnly = a.Where( aa => !b.Contains(aa));
     var inBOnly = b.Where( bb => !a.Contains(bb));
     return inAOnly.Union(inBOnly).ToArray();
}
public static string[] InBoth (string[] a, string[] b )
{
     return a.Intersect(b).ToArray();
}
# Test
## Code 
string[] a = {"some", "random", "string"};
string[] b = {"some", "other", "random", "string"};
string[] differences = GetDifferences(a,b);
foreach( var diff in differences ) Console.WriteLine(diff);
Console.WriteLine("----------------------");
foreach( var diff in InBoth(a,b) ) Console.WriteLine(diff);
## Ouput
// .NETCoreApp,Version=v3.0
other
----------------------
some
random
string
