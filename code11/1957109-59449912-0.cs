public static object DoSomething<TSource>(this TSource source, string somethingElse)
{
    if (source is System.Collections.IEnumerable)
    {
        Console.WriteLine("List");
    }
    else
    {
        Console.WriteLine("Instance");
    }
    return null;
}
