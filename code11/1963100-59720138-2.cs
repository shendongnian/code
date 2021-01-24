public static class Program
{
    public static readonly string Foo = Current;
    
    public static string Current => Languages[0];
    public static readonly List<string> Languages = new List<string>
    {
        "en"
    };
    
    public static void Main()
    {
        Console.WriteLine(Foo);
    }
}
[SharpLab](https://sharplab.io/#v2:C4LgTgrgdgPgAgJgIwFgBQcAMACOSAsA3OogMzoDe62NupuSAbNmAKYCGAJgPZQA2ATwY4AYt27YAvNgDCEMGyjBiaarTj08zPDjkLWSqQD5sAGXZQA5hHaXWAZwDamALoq1NDQ2ZsuvQWYAlvbAADw6JuZWNnb2UthQrADuQSHhSJhGHthUaLT52ABEBoXZAL7ueeoICNm5BepIAJwAFGLcAJQq+WXoZUA=)
Static members are initialized in the order they're declared. `Foo` is initialized before `Languages` is assigned, and so you see a `NullReferenceException`.
I guess that Resharper's being very pessimistic here, and only considering `Current` in isolation, regardless of whether there's actually another static member that might access it before `Languages` is initialised.
-------------
You could also have something diabolical like this, where the construction of `Languages` causes something to access `Program.Current`:
public static class Program
{
    public static string Current => Languages[0].Value;
    public static readonly List<Language> Languages = new List<Language>() { new Language() };
    
    public static void Main()
    {
        Console.WriteLine(Current);
    }
}
public class Language
{
    public string Value { get; } = Program.Current;
}
(It's a silly example, but it shows that it's perhaps harder for Resharper to prove that nothing accesses `Program.Current` before `Program`'s type initializer has finished running, than you might expect).
