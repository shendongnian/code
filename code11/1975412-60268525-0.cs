cs
public class Bar
{
    public void SomeMethod()
    {
    }
}
public class Container<T> where T : Bar
{
    public T Content;
    public void SomeMethod()
    {
        Content?.SomeMethod();
    }
}
Generic types are resolved at runtime, so you can't know what is the type `T` exactly and does it have `SomeMethod()` or not. You can create a base class or interface to use it as constraint instead of using `where T : Bar`.
Another option is cast `Content` to the concrete type (or use a reflection even), but you lose all benefits of generic types
cs
public void SomeMethod()
{
    if (Content is Bar bar)
    {
        bar.SomeMethod();
    }
}
