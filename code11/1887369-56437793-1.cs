C#
private const int blockSize = 1024;
private static IEnumerable<byte> GetCryptoStream()
{
    var data = new byte[blockSize];
    var crypto = new RNGCryptoServiceProvider();
    while (true)
    {
        crypto.GetBytes(data);
        foreach (var b in data) yield return b;
    }
}
private static IEnumerable<int> GetCryptoStream(int radix)
{
    if (radix <= 0 || radix >= 256) throw new ArgumentException("radix should be > 0 and < 256");
    var rem = 256 % radix;
    foreach (var b in GetCryptoStream())
    {
        if (b < rem) continue;      // rejection sampling
        yield return b % radix;
    }
}
private static string Serial(string type, int length)
{
    if (length < 1) return "";
    string chars;
    switch (type)
    {
        // ...
    }
    var result = new StringBuilder(length);
    foreach (var k in GetCryptoStream((byte) chars.Length).Take(length))
    {
        result.Append(chars[k]);
    }
    return result.ToString();
}
----------
Test code,
C#
[TestCase(3)]
[TestCase(6)]
[TestCase(5)]
[TestCase(75)]
public void TestCrypto(int n)
{
    const int m = 1000 * 1000 * 100;
    var count = new int[n];
    foreach (var k in GetCryptoStream((byte) n).Take(m))
    {
        count[k] ++;
    }
    Console.WriteLine($"Expected : {1.0 / n:F4}, Actual :");
    for (int i = 0; i < count.Length; i++)
    {
        Console.WriteLine($"{i} : {count[i] / (double) m:F4}");
    }
}
result for 6
Expected : 0.1667, Actual :
0 : 0.1667
1 : 0.1667
2 : 0.1667
3 : 0.1667
4 : 0.1667
5 : 0.1666
