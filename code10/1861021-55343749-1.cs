string[] dirNames = new string[10000];
for (i = 0; i < 10000; ++i)
    dirNames[i] = GetRandomString(dirNameLength); // generates "unique name";
foreach (var dr in dirNames.GroupBy(x => x).Select(x => new { Name = x.Key, Count = x.Count() }).Where(x => x.Count > 1))
{
    Console.WriteLine($"{dr.Count} {dr.Name}");
}
Try this. Аnd don't forget that filenames are case insensitive, so you should use only 36 characters, not 62.
private static readonly char[] charList = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
private static readonly Random _random = new Random();
private static string GetRandomString(int length)
{
    if (length < 1)
        throw new ArgumentOutOfRangeException("Length must be greater than 0!");
    return new string(Enumerable.Repeat(charList, length).Select(s => s[_random.Next(s.Length)]).ToArray());
}
