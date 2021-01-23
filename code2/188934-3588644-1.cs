    string foo = "smith;rodgers;McCalne";
    foreach (string bar in foo.Split2(";"))
    {
        Console.WriteLine(bar);
    }
    // ...
    public static class StringExtensions
    {
        public static IEnumerable<string> Split2(this string source, string delim)
        {
            // argument null checking etc omitted for brevity
            int oldIndex = 0, newIndex;
            while ((newIndex = source.IndexOf(delim, oldIndex)) != -1)
            {
                yield return source.Substring(oldIndex, newIndex - oldIndex);
                oldIndex = newIndex + delim.Length;
            }
            yield return source.Substring(oldIndex);
        }
    }
