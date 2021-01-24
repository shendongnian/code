c#
static class Base36
{
    public static string EncodeAsFixedWidth(long value, int totalWidth)
    {
        string base36Text = Encode(value);
        return base36Text.PadLeft(totalWidth, '0');
    }
    public static string Encode(long value)
    {
        StringBuilder sb = new StringBuilder();
        while (value >= 36)
        {
            int digit = (int)(value % 36);
            char digitCharacter = _GetDigitCharacter(digit);
            sb.Append(digitCharacter);
            value = value / 36;
        }
        sb.Append(_GetDigitCharacter((int)value));
        _Reverse(sb);
        return sb.ToString();
    }
    public static long Decode(string base36Text)
    {
        long value = 0;
        foreach (char ch in base36Text)
        {
            value = value * 36 + _GetBase36DigitValue(ch);
        }
        return value;
    }
    private static void _Reverse(StringBuilder sb)
    {
        for (int i = 0; i < sb.Length / 2; i++)
        {
            char ch = sb[i];
            sb[i] = sb[sb.Length - i - 1];
            sb[sb.Length - i - 1] = ch;
        }
    }
    private static int _GetBase36DigitValue(char ch)
    {
        return ch < 'A' ? ch - '0' : ch - 'A' + 10;
    }
    private static char _GetDigitCharacter(int digit)
    {
        return (char)(digit < 10 ? '0' + digit : 'A' + digit - 10);
    }
}
Okay, now that we have that, it's easy to write a class to handle the encoding for the database value itself:
c#
static class DatabaseDateTime
{
    private static readonly DateTimeOffset _epoch = new DateTimeOffset(1990, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);
    public static DateTimeOffset Decode(string databaseText, int timeZoneOffsetHours)
    {
        double secondsSinceEpoch = Base36.Decode(databaseText) / 50d;
        DateTimeOffset result = _epoch.AddSeconds(secondsSinceEpoch);
        return new DateTimeOffset(result.AddHours(timeZoneOffsetHours).Ticks, TimeSpan.FromHours(timeZoneOffsetHours));
    }
    internal static string Encode(DateTimeOffset testResult)
    {
        double secondsSinceEpoch = testResult.Subtract(_epoch).TotalSeconds;
        return Base36.EncodeAsFixedWidth((long)(secondsSinceEpoch * 50), 7);
    }
}
Finally, for the purpose of this exercise, I wrote a little sample program that uses your example values to verify that the above code works as expected and desired:
c#
static void Main(string[] args)
{
    (string DatabaseText, DateTimeOffset EncodedDateTime)[] testCases =
    {
        ("A7LXZMM", DateTimeOffset.Parse("2004-02-02 09:34:47.000 +01:00")),
        ("KWZKXEX", DateTimeOffset.Parse("2018-11-09 11:15:46.000 +01:00")),
        ("LIZTMR9", DateTimeOffset.Parse("2019-09-13 11:49:46.000 +01:00"))
    };
    List<DateTimeOffset> testResults = new List<DateTimeOffset>(testCases.Length);
    foreach (var testCase in testCases)
    {
        DateTimeOffset decodedDateTime = DatabaseDateTime.Decode(testCase.DatabaseText, 1);
        // Compare as string, because reference data was provided as string and is missing
        // some of the precision in the actual database text provided.
        if (decodedDateTime.ToString() != testCase.EncodedDateTime.ToString())
        {
            WriteLine($"ERROR: {testCase.DatabaseText} -- expected: {testCase.EncodedDateTime}, actual: {decodedDateTime}");
        }
        testResults.Add(decodedDateTime);
    }
    foreach (var testCase in testResults.Zip(testCases, (r, c) => (Result: r, DatabaseText: c.DatabaseText)))
    {
        string base36Text = DatabaseDateTime.Encode(testCase.Result);
        if (base36Text != testCase.DatabaseText)
        {
            WriteLine($"ERROR: {testCase.Result} -- expected: {testCase.DatabaseText}, actual: {base36Text}");
        }
    }
}
When I run the above code, I get no output, just as desired (i.e. the only `WriteLine()` calls above are executed only when the program's computations _don't_ match what's expected).
