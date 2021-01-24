csharp
public static void ConvertToCollectionOfNullable<T>(
    this ICollection<T> source, 
    ICollection<T?> destination) where T : struct
{
    for (int i = 0; i < source.Count; i++)
    {
        destination.Add(source.ElementAt(i));
    }
}
also, you can use `foreach` on a collection for cleaner code.
csharp
public static void ConvertToCollectionOfNullable<T>(
    this ICollection<T> source,
    ICollection<T?> destination) where T : struct
{
    foreach (var element in source)
    {
        destination.Add(element);
    }
}
