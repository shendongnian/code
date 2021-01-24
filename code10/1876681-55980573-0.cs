#nullable enable
class Box<T> {
    public T Value { get; }
    public Box(T value) {
        Value = value;
    }
}
static class CreateDefaultBox
{
    public static Box<T> ValueTypeNotNull<T>() where T : struct
        => new Box<T>(default);
    public static Box<T?> ValueTypeNullable<T>() where T : struct
        => new Box<T?>(null);
    public static Box<T> ReferenceTypeNotNull<T>() where T : class, new()
        => new Box<T>(new T());
    public static Box<T?> ReferenceTypeNullable<T>() where T : class
        => new Box<T?>(null);
}
This *seems* type safe to me, at the cost of more ugly call sites (`CreateDefaultBox.ReferenceTypeNullable<object>()` instead of `Box<object?>.CreateDefault()`). In the example class I posted I'd just remove the methods completely and use the `Box` constructor directly. Oh well.
