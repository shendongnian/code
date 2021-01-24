public class BarAD
{
    private List<Type> Types = new List<Type>();
    public void Add<T>() where T : Foo
    {
        Types.Add( typeof( T ) );
    }
}
static void Main( string[] args )
{
    BarAD bar = new BarAD();
    bar.Add<FooA>();
    bar.Add<FooD>();
}
Although I feel it's kind of strange. Usually I'd like to utilize polymorphism instead of types.
