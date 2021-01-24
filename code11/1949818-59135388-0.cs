public interface IFoo
{
    string Name { get; set; }
}
public interface IBar : IFoo
{
    new string Name { get; set; }
}
public class Implementation : IBar
{
    string IBar.Name { get; set; } = "Bar";
    string IFoo.Name { get; set; } = "Foo";
}
If you cast Implementation class to IBar, the value will be Bar and if you cast it to IFoo, the value will be Foo.
