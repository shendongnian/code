public static ILookup<string, string> CreateLookup(string input)
{
    Debug.WriteLine(input);
    return input.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(x => x.Split(new string[] {": "}, StringSplitOptions.None))
        .ToLookup(x => x[0], x => x[1], StringComparer.InvariantCultureIgnoreCase);
}
