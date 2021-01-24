public static class RandomExtensions
{
    private const long IntegerRange = (long)int.MaxValue - int.MinValue;
    public static int NextInclusive(this Random random, int minValue, int maxValue)
    {
        if (minValue > maxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(minValue));
        }
        var buffer = new byte[4];
        random.NextBytes(buffer);
        var a = BitConverter.ToInt32(buffer, 0);
        var b = a - (long)int.MinValue;
        var c = b * (1.0 / IntegerRange);
        var d = c * ((long)maxValue - minValue + 1);
        var e = (long)d + minValue;
        return (int)e;
    }
}
new Random(0).NextInclusive(int.MaxValue - 1, int.MaxValue); // returns int.MaxValue
new Random(1).NextInclusive(int.MaxValue - 1, int.MaxValue); // returns int.MaxValue - 1
new Random(0).NextInclusive(int.MinValue, int.MinValue + 1); // returns int.MinValue + 1
new Random(1).NextInclusive(int.MinValue, int.MinValue + 1); // returns int.MinValue
new Random(-451732719).NextInclusive(int.MinValue, int.MaxValue); // returns int.MinValue
new Random(-394328071).NextInclusive(int.MinValue, int.MaxValue); // returns int.MaxValue
