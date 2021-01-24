cs
var seen = new HashSet<string>();
IEnumerable<string> replaced =
    from line in data.Split(Environment.NewLine)
    select seen.Add(line) ? line : "REPETITION";
foreach (string line in replaced)
{
    Console.WriteLine(line);
}
But more realistically you will read your lines from a file, then it's likely you will use a `Stream`. In that case you may use a method like this:
cs
public static IEnumerable<string> ReplaceRepeatedLines(Stream data, Encoding encoding)
{
    var seen = new HashSet<string>();
    using var reader = new StreamReader(data, encoding);
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        if (!seen.Add(line))
        {
            yield return "REPETITION";
        }
        else
        {
            yield return line;
        }
    }
}
