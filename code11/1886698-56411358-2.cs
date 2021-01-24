C#
public class BlumBlumShub
{
    private readonly ulong m;
    private ulong x;
    public BlumBlumShub(int m, int seed)
    {
        this.m = (ulong) m;
        x = (ulong)seed;
    }
    public int Next()
    {
        x = (x * x) % m;
        return (int)x;
    }
}
[reference][1]
----------
**Edit:** If you really need very large number you can adapt it easily:
C#
public class BlumBlumShub
{
    private readonly BigInteger m;
    private BigInteger x;
    public BlumBlumShub(BigInteger m, BigInteger seed)
    {
        this.m = m;
        x = seed;
    }
    public BigInteger Next()
    {
        x = (x * x) % m;
        return x;
    }
}
  [1]: https://en.wikipedia.org/wiki/Blum_Blum_Shub
