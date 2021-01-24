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
    foreach (var cd in columnDefinitions)
    {
        var title = cd.title;
        builder.Append(PrepareCsvValue(cd.title));
        builder.Append(',');
    }
    builder.AppendLine();
    foreach (var item in items)
    {
        foreach (var cd in columnDefinitions)
        {
            builder.Append(PrepareCsvValue(cd.valueProvider(item)));
            builder.Append(',');
        }
        builder.AppendLine();
    }
    return builder.ToString();
}
private static string PrepareCsvValue(string value)
{
    value = value.Replace("\"", "\"\"");
    if (value.Contains(','))
    {
        value = $"\"{value}\"";
    }
    return value;
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
**Note 2:**  
I added code that handles special characters inside values.  
As per specification, values may use delimiters, if they are surounded by the " character.  
Existing " characters need to be escaped with another ", thus (a"b -> a""b).
