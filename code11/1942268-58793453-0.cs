public class GetClaims
{
    public string Tenantid { get; }
    public string Username { get; }
    public bool Isauthenticated { get; }
    GetClaims()
    { 
       ...
    }
}
# Static constructors
[Static constructors](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-constructors) are called only once, in normal circumstances. 
public class C {
    static C() { Console.WriteLine("Static!");} 
    public C() { Console.WriteLine("Instance!");}
}
class Program
{
    static void Main(string[] args)
    {
        var c1 = new C();
        var c2 = new C();
    }
Static!
Instance!
Instance!
