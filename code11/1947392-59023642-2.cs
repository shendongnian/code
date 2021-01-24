public static T Get<T>(T value)
{
    return value;
}
If we call it like `Get<string>(s)`, the return is non-nullable, and if we do `Get<string?>(s)`, it's nullable.
However if you are calling it with a generic argument like `Get<T>(x)` and `T` isn't resolved, for example it is a generic argument to your generic class like below... 
class MyClass<T>
{
    void Method(T x)
    {
        var result = Get<T>(x);
        // is result nullable or non-nullable? It depends on T
    }
}
Here the compiler does not know if eventually it will be called with a nullable or non-nullable type.
There is a new type constraint we can use to signal that `T` cannot be null:
public static T Get<T>(T value) where T: notnull
{
    return value;
}
However, where `T` is unconstrained and still open, the nullability is unknown.
If they were treated as nullable then you could write the following code:
class MyClass<T>
{
    void Method(T x)
    {
        var result = Get<T>(x);
        // reassign result to null, cause we we could if unknown was treated as nullable
        result = null;
    }
}
In the case where `T` was not nullable, we should have got a warning. So with unknown nullability types, we want warnings when dereferencing, but also warnings for assigning potentially `null`.
