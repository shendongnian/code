cs
using System.Diagnostics.CodeAnalysis;
class Box<T>
{
    [MaybeNull]
    public T Value { get; }
    public Box([AllowNull] T value)
    {
        Value = value;
    }
    public static Box<T> CreateDefault()
    {
        return new Box<T>(default);
    }
}
Please see https://devblogs.microsoft.com/dotnet/try-out-nullable-reference-types for more information, particularly the section "[the issue with T?](https://devblogs.microsoft.com/dotnet/try-out-nullable-reference-types/#the-issue-with-t)".
