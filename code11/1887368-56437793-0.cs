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
