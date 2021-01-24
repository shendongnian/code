services.AddTransient(typeof(IA<>), typeof(A<>));
services.AddTransient<AOptions>(sp => new AOptions { X = "1", Y = "2" });
public class A<T> : IA<T>
{
    private readonly AOptions _aOptions;
    public A(AOptions aOptions = null)
    {
        _aOptions = aOptions;
    }
}
public class AOptions
{
    public string X { get; set; }
    public string Y { get; set; }
}
