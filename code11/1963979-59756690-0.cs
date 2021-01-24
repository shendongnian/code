csharp
// error CS0121: The call is ambiguous between the following methods or properties:
// 'Console.WriteLine(char[])' and 'Console.WriteLine(string)'
Console.WriteLine(null);
So why is `vv` null in the second case? Because you started with null, and added to it. I suspect the binder is converting both `null` and the non-null integer to `int?` and then performing addition using the lifted addition operator. That reasoning is only an educated guess, but certainly the result is null. (You can check that with normal null checks on the result.)
The fix is to start with "the first element in the array" for the addition rather than with null, and only return null if the input array is either null or empty (or if a real addition ends up with null - which it could do if null is one of the elements in the array). You can also fix `Console.WriteLine` causing a problem even in that case by using `object` as the type of the local variable receiving the result, rather than `dynamic`. Here's an example with all that fixed, as well as using more idiomatic names:
csharp
using System;
using System.Linq;
public class Program
{
    public static dynamic Sum(params dynamic[] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            return null;
        }
        dynamic result = arr[0];
        foreach (var item in arr.Skip(1))
        {
            result += item;
        }
        return result;
    }
    
    static void Main(string[] args)
    {
        object sum = Sum("my", "name");
        Console.WriteLine(sum);
        sum = Sum(5, 6, 7);
        Console.WriteLine(sum);
        Console.WriteLine(null);
    }
}
Output:
text
myname
18
