return string.Equals(obj1.ToString(), obj2.ToString(), comparisonType);
1. You've already null checked obj1 and obj2
2. Casting obj1 as string isn't actually converting it into a string, it just means the compiler is letting you use string-like methods on it.
Edit: for clarity, this would be my full static method:
public static class ObjectHelper
{
    public static bool EqualStrings(object obj1, object obj2, StringComparison comparisonType)
    {
        return string.Equals(obj1?.ToString(), obj2?.ToString(), comparisonType);
    }
}
I personally wouldn't have an extension method on object - it's going to pollute your intellisense. And I would use null check operators for brevity.
