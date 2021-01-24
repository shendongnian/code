csharp
static void Foo(string someVariable, [CallerMemberName] string methodName = "")
{
    if (!FulfilsCondition(someVariable))
        Console.WriteLine($"{methodName} passed a bad paramter!");
    // More code
}
static void BadMethod()
{
    string wrong = "";
    Foo(wrong);
}
Would print:
BadMethod passed a bad paramter!
