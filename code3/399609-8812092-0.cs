public static class IntegerExtensions
{
    public static bool IsLargerThan(this int? number, int numberToCompare)
    {
        return number.HasValue && number > numberToCompare;
    }
}
...
// Usage:
int? val1 = 15;
int val2 = 10;
if (val1.IsLargerThan(val2))
{
    // Do Something
}
