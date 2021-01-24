C#
public static List<T> GetFieldValues<T>()
{
    return typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static)
              .Where(f => f.FieldType == typeof(T))
              .Select(f => (T)f.GetValue(null))
              .ToList();
}
To use `is`, you'd want to get the value from the field you're looking at, and then check if the type of the *value* `is T`. But there's already an `OfType()` LINQ method for that, so we'll use it:
C#
public static List<T> GetStaticFieldValuesOfType<T>()
{
    return typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static)
              .Select(f => (T)f.GetValue(null))
              .OfType<T>()
              .ToList();
}
