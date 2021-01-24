public class ProviderManager
{
    private readonly Dictionary<Type, Func<object>> _providerMapping =
        new Dictionary<Type, Func<object>>();
    public void Register<T>(IProvider<T> provider)
    {
        _providerMapping .Add(typeof(T), () => provider.GetObject());
    }
    public T GetObject<T>()
    {
        if (!_providerMapping.TryGetValue(typeof(T), out var factory))
            throw ...
        return (T)factory();
    }
}
Then:
    public void Register()
    {
        _Manager.Register(this);
    }
We have a dictionary full of lots of delegates which return different types. We have to use the common type among these, which is `object`, and store `Func<object>`s in our dictionary. We then cast the `object` to the appropriate `T` in `GetObject<T>()`.
