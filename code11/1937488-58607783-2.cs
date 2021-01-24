public static string[] GetDifferences1(string[] a, string[] b )
{
     var inAOnly = a.Where( aa => !b.Contains(aa));
     var inBOnly = b.Where( bb => !a.Contains(bb));
     return inAOnly.Union(inBOnly).ToArray();
}
public static string[] GetDifferences2(string[] a, string[] b )
{
     var inAOnly = a.Except(b);
     var inBOnly = b.Except(a);
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
foreach( var diff in GetDifferences1(a,b) ) Console.WriteLine(diff);
Console.WriteLine("----------------------");
foreach( var diff in GetDifferences2(a,b) ) Console.WriteLine(diff);
Console.WriteLine("----------------------");
foreach( var inBoth in InBoth(a,b) ) Console.WriteLine(inBoth);
## Ouput
// .NETCoreApp,Version=v3.0
other
----------------------
other
----------------------
some
random
string
