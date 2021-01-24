csharp
public static partial class ExtensionMethodsForValueTypes
{
    // Nullable to nullable
    public static T? NullIf<T>(this T? value, T? other)
        where T : struct
    {
        return value == null || EqualityComparer<T>.Default.Equals((T)value, other) ? null : value;
    }
}
public static partial class ExtensionMethodsForReferenceTypes
{
    // Nullable to nullable
    public static T NullIf<T>(this T value, T other)
        where T : class
    {
        return EqualityComparer<T>.Default.Equals(value, other) ? null : value;
    }
}
The compiler will select the correct method for reference types and nullable value types in the manner that Jon Skeet and Eric Lippert describe in their respective blogs.
The distinction I mentioned above includes a `ToNullIf` extension method, which takes (non-nullable) value types.  It can be in the same class as the `NullIf` that takes *nullable* value types.  It can't, however, also be called `NullIf`.  I'll defer to the Masters once again for the reasons for that.
Fortunately, though, indicating a lift to nullable through a different method name actually can be pretty useful in conveying intent more clearly, as well as having affordances conveyed to you in the IDE, such as when IntelliSense doesn't show `NullIf` for plain value types or `ToNullIf` for nullable value types.  Yet, thanks to the partial matching IntelliSense does in VS 2017, typing "NullIf" will show `ToNullIf` if that's what's available.
csharp
partial class ExtensionMethodsForValueTypes
{
    // Non-nullable to nullable
    public static T? ToNullIf<T>(this T value, T other)
        where T : struct
    {
        return EqualityComparer<T>.Default.Equals(value, other) ? (T?)null : value;
    }
}
If you want to add string specialization on top of the `NullIf` that takes reference types, you can, but you can't have a default parameter without at least one non-defaulted parameter to distinguish it from the generic version at the call sites.  In your case, you need to provide two overloads.  An overload without the `ignoreCase` parameter prevents `NullIf<string>` from being selected because the former is a more specific type match.  One *with* the `ignoreCase` parameter gives you the case-insensitivity you desire.
csharp
partial class ExtensionMethodsForReferenceTypes
{
    public static string NullIf(this string value, string other) => NullIf(value, other, false);
    public static string NullIf(this string value, string other, bool ignoreCase)
    {
        return String.Compare(value, equalsThis, ignoreCase) == 0 ? null : value
    }
}
If you have no interest in the parity between reference types and nullable value types in the name of the methods for the **nullable to nullable** case, there's no reason you couldn't drop the `ExtensionMethodsForValueTypes.NullIf` extension method above and rename `ToNullIf` to `NullIf`.  Ultimately, it's the separation into different classes that solves the original problem.
**One final note:** None of this takes into account nullable vs. non-nullable *reference types* in C# 8.0, in part because it's new and in part because the distinction simply can't be made or, if it can, it requires a different technique entirely.
