static (bool success, string name1, string name2) MyFunc()
{
    if (DateTime.Now.Year > 2020) return (false, "", "");
        return (true, "some value", "some value");
}
static void f()
{
    if (MyFunc() is var (b, name1,name2) && !b) return;
        Console.WriteLine(name1);
}
    
public static void Main()
{
    f();
}
