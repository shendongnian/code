cs
interface IFoo { }
And inherit it in your type-specific Foo (with generic parameters), like:
cs
interface IFoo<T> : IFoo {}
This way you can just have a `List<IFoo>` and add `IFoo<T>` instead.
More examples:
cs
class FooCollection {
    private List<IFoo> _collection;
    public FooCollection()
    {
        _collection = new List<IFoo>();
    }
    public void Add(IFoo foo)
    {
        _collection.Add(foo);
    }
    public void Remove(IFoo foo)
    {
        _collection.Remove(foo);
    }
}
