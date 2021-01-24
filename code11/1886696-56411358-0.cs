C#
public class BlumBlumShub
{
    private readonly ulong m;
    private ulong x;
    public BlumBlumShub(ulong m, int seed)
    {
        this.m = m;
        x = (ulong)seed;
    }
    public int Next()
    {
        x = (x * x) % m;
        return (int)x;
    }
}
[reference][1]
  [1]: https://en.wikipedia.org/wiki/Blum_Blum_Shub
