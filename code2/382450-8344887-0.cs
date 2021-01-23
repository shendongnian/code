class Program
{
    static void Main(string[] args)
    {
        using (var b = GetReader())
        {
        }
    }
    static B GetReader()
    {
        using (var a = new A())
        {
            return new B(a);
        }
    }
}
class A : IDisposable
{
    public void Dispose()
    {
        Console.WriteLine("Dispose A");
    }
}
class B : IDisposable
{
    public B(object obj)
    {
    }
    public void Dispose()
    {
        Console.WriteLine("Dispose B");
    }
}
