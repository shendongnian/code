static void PrintSum(int num1, int num2, int result) {
    Console.WriteLine("{0} + {1} = {2}", num1, num2, result);
}
PrintSum(num1, num2, num1+num2);
// 10 + 2 = 12
## `params object[]`
In fact, [`WriteLine`](https://docs.microsoft.com/en-us/dotnet/api/system.console.writeline?view=netframework-4.8#System_Console_WriteLine_System_String_System_Object___) can accept `params object[]` and when `WriteLine` is called the arguments are already evaluated. I hope the snippets below helps to showcase what's happening.
## Snippet 1
static void WriteLineWrapper(string template, params object[] objects) 
{
    for(int i = 0; i< objects.Length; i++ )
    {
        Console.WriteLine($"{i}: {objects[i]}");
    }
    Console.WriteLine(template, objects);
}
(...)
WriteLineWrapper("{0} + {1} = {2}", num1, num2, num1+num2);
Output
0: 10
1: 2
2: 12
10 + 2 = 12
## Snippet 2
static void Print(params object[] toPrint) {
    // Note the change of order 0,2,1,3, not 0,1,2,3
    Console.WriteLine("{0} {2} {1} = {3}", toPrint[0], toPrint[1], toPrint[2], toPrint[3]);
}
static void Main(string[] args)
{
    int num1 = 10;
    int num2 = 2;
    Print(num1, num2, "+", num1+num2);
    Print(num1, num2, "-", num1-num2);
    Print(num1, num2, "*", num1*num2);
    Print(num1, num2, "/", num1/num2);
    Print(num1, num2, "mod", num1%num2);
    Print(num1, num2, "+"); // Oops
}
Output
10 + 2 = 12
10 - 2 = 8
10 * 2 = 20
10 / 2 = 5
10 mod 2 = 0
Unhandled exception. System.IndexOutOfRangeException: Index was outside the bounds of the array.
# String interpolation
BTW. You could use [$ - string interpolation (C# reference)](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated).
Console.WriteLine($"{num1} + {num2} = {num1+num2}");
Console.WriteLine($"{num1} - {num2} = {num1-num2}");
Console.WriteLine($"{num1} x {num2} = {num1*num2}");
Console.WriteLine($"{num1} / {num2} = {num1/num2}");
Console.WriteLine($"{num1} mod {num2} = {num1%num2}");
