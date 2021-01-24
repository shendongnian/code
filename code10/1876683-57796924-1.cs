cs
#nullable enable
using System.Diagnostics.CodeAnalysis;
class Box<T>
{
    [MaybeNull]
    public T Value { get; }
    public Box([AllowNull] T value) // 1
    {
        Value = value;
    }
    public static Box<T> CreateDefault()
    {
        return new Box<T>(default(T)!); // 2
    }
    public static void UseStringDefault()
    {
        var box = Box<string>.CreateDefault();
        _ = box.Value.Length; // 3
    }
    public static void UseIntDefault()
    {
        var box = Box<int>.CreateDefault();
        _ = box.Value.ToString(); // 4
    }
}
Notes:
1. The flow analysis attributes currently affect only the *calls* to the annotated members, not the *implementations*. This means that if we deleted the `[MaybeNull]` attribute from the property `Value` we would not get a warning about assigning the `[AllowNull] T value` parameter to it. The `[AllowNull]` in practice just prevents possible-null-argument warnings from being given at the call site.
2. The compiler's analysis of unconstrained (i.e. not known to be value or reference type) type parameters is limited. At this point this means the compiler gives a warning: 'A default expression introduces a null value when 'T' is a non-nullable reference type.'. Because the compiler can't always determine when a usage of a value of type T is null-safe or not, it instead gives warnings in places where T could be a non-nullable reference type, yet 'null' could be introduced. The most obvious place this happens is with `default(T)`, but it may also happen at the invocation of generic methods whose returns are annotated with `[MaybeNull]`. For now we handle the problem by suppressing the warning with `default(T)!`.
3. This is a simpler case where we give a nullability warning at the dereference of `box.Value` because of the `[MaybeNull]` annotation on the property.
4. In this case the MaybeNull attribute does not cause a warning at the usage, because `box.Value` is a non-nullable value type.
Please see https://devblogs.microsoft.com/dotnet/try-out-nullable-reference-types for more information, particularly the section "[the issue with T?](https://devblogs.microsoft.com/dotnet/try-out-nullable-reference-types/#the-issue-with-t)".
