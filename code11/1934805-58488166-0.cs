Console.WriteLine($"{string bar = "hello"}"); // This gives error CS1525: Invalid expression term 'string'
So instead, declare it outside the string interpolation, and you can assign it in the interpolation expression with an assignment expression.
string bar;
Console.WriteLine($"{bar = "hello"}"); // This is OK
Console.WriteLine(bar);
**Your specific example:**
string msg0, msg1;
Console.WriteLine($"0:{msg0 = message[0].ConvertToString()} 1:{msg1 = message[1].ConvertToString()}");
Console.WriteLine(msg0);
Console.WriteLine(msg1);
**Bonus tip**:  You can, however, use an `out` variable declaration in an interpolation expression.  The scope is the same as the line (not somehow local to the interpolation expression).  e.g.:
class Program
{
    static string Test(out string x, string y) {
        return x = y;
    }
    static void Main(string[] args)
    {
        Console.WriteLine($"{Test(out string bar, "Hello")}");
        Console.WriteLine(bar);
    }
}
