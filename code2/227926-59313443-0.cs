    public static int GetNumberOfDigits(this long value)
    {
        return value.GetDigits().Count();
    }
    public static IEnumerable<int> GetDigits(this long value)
    {
        do
        {
            yield return (int)(value % 10);
            value /= 10;
        } while (value != 0);
    }
