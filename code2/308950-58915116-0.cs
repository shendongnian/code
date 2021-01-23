PS C:\dev\Spaces> dotnet run -c release
// .NETCoreApp,Version=v3.0
Seed=7, n=20, s.Length=2828670
Regex by SLaks            1407ms, len=996757
StringBuilder by Blindy    154ms, len=996757
Array                      130ms, len=996757
NoIf                        91ms, len=996757
All match!
# Methods
private static string WithNoIf(string s)
{
    var dst = new char[s.Length];
    uint end = 0;
    char prev = char.MinValue;
    for (int k = 0; k < s.Length; ++k)
    {
        var c = s[k];
        dst[end] = c;
        // We'll move forward if the current character is not ' ' or if prev char is not ' '
        // To avoid 'if' let's get diffs for c and prev and then use bitwise operatios to get 
        // 0 if n is 0 or 1 if n is non-zero
        uint x = (uint)(' ' - c) + (uint)(' ' - prev); // non zero if any non-zero
        end += ((x | (~x + 1)) >> 31) & 1; // https://stackoverflow.com/questions/3912112/check-if-a-number-is-non-zero-using-bitwise-operators-in-c by ruslik
        prev = c;
    }
    return new string(dst, 0, (int)end);
}
private static string WithArray(string s)
{
    var dst = new char[s.Length];
    int end = 0;
    char prev = char.MinValue;
    for (int k = 0; k < s.Length; ++k)
    {
        char c = s[k];
        if (c != ' ' || prev != ' ') dst[end++] = c;
        prev = c;
    }
    return new string(dst, 0, end);
}
# Test code
public static void Main()
{
    const int n = 20;
    const int seed = 7;
    string s = GetTestString(seed);
    var fs = new (string Name, Func<string, string> Func)[]{
        ("Regex by SLaks", WithRegex),
        ("StringBuilder by Blindy", WithSb),
        ("Array", WithArray),
        ("NoIf", WithNoIf),
    };
    Console.WriteLine($"Seed={seed}, n={n}, s.Length={s.Length}");
    var d = new Dictionary<string, string>(); // method, result
    var sw = new Stopwatch();
    foreach (var f in fs)
    {
        sw.Restart();
        var r = "";
        for( int i = 0; i < n; i++) r = f.Func(s);
        sw.Stop();
        d[f.Name] = r;
        Console.WriteLine($"{f.Name,-25} {sw.ElapsedMilliseconds,4}ms, len={r.Length}");
    }
    Console.WriteLine(d.Values.All( v => v == d.Values.First()) ? "All match!" : "Not all match! BAD");
}
private static string GetTestString(int seed)
{
    // by blindy from https://stackoverflow.com/questions/6442421/c-sharp-fastest-way-to-remove-extra-white-spaces
    var rng = new Random(seed);
    // random 1mb+ string (it's slow enough...)
    StringBuilder ssb = new StringBuilder(1 * 1024 * 1024);
    for (int i = 0; i < 1 * 1024 * 1024; ++i)
        if (rng.Next(5) == 0)
            ssb.Append(new string(' ', rng.Next(20)));
        else
            ssb.Append((char)(rng.Next(128 - 32) + 32));
    string s = ssb.ToString();
    return s;
}
