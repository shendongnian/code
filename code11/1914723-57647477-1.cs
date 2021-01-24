csharp
public static string ToCsv<T>(this IEnumerable<T> items, params (string title, Func<T, string> valueProvider)[] columnDefinitions)
{
    if (items == null)
    {
        throw new ArgumentNullException(nameof(items));
    }
    if (columnDefinitions == null || columnDefinitions.Length == 0)
    {
        throw new ArgumentException(nameof(columnDefinitions));
    }
    var builder = new StringBuilder();
    // Add header
    foreach (var cd in columnDefinitions)
    {
        builder.Append(cd.title);
        builder.Append(',');
    }
    builder.AppendLine();
    // Add every item
    foreach (var item in items)
    {
        foreach (var cd in columnDefinitions)
        {
            builder.Append(cd.valueProvider(item));
            builder.Append(',');
        }
        builder.AppendLine();
    }
    return builder.ToString();
}
Here is an example on how to use it:  
csharp
public static void Example()
{
    var items = new TimeSpan[]
    {
        new TimeSpan(0), 
        new TimeSpan(0, 0, 0, 1), 
        new TimeSpan(0, 0, 1, 1), 
        new TimeSpan(0, 1, 1, 1),
        new TimeSpan(1, 1, 1, 1)
    };
    var csvText = items.ToCsv(
        ("Days", ts => ts.Days.ToString()),
        ("Hours", ts => ts.Hours.ToString()),
        ("Minutes", ts => ts.Minutes.ToString()),
        ("Seconds", ts => ts.Seconds.ToString()));
    // Do something with the csv text.
}
This is just to get the csv text.  
You can create another method that also exports it to a file, using the first method.  
**Note:**  
I used named types for the column definitions.  
That makes for a nice formating in the method call, but can be confusing to some.  
You can find more information on named tuples [here](https://docs.microsoft.com/en-us/dotnet/csharp/tuples).
