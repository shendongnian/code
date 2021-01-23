Lookup-Table: 439 ms
Binary-Search: 1069 ms
If-Chain: 1409 ms
Log10: 1145 ms
While: 1768 ms
String: 5153 ms
**Lookup table version:**
c#
static byte[] _0000llll = new byte[0x10000];
static byte[] _FFFFllll = new byte[0x10001];
static sbyte[] _hhhhXXXXdigits = new sbyte[0x10000];
// Special cases where the high DWORD is not enough information to find out how
// many digits.
static ushort[] _lowordSplits = new ushort[12];
static sbyte[] _lowordSplitDigitsLT = new sbyte[12];
static sbyte[] _lowordSplitDigitsGE = new sbyte[12];
static Int32Extensions()
{
    // Simple lookup tables for number of digits where value is 
    //    0000xxxx (0 .. 65535)
    // or FFFFxxxx (-1 .. -65536)
    precomputePositiveLo16();
    precomputeNegativeLo16();
    // Hiword is a little more complex
    precomputeHiwordDigits();
}
private static void precomputeHiwordDigits()
{
    int b = 0;
    for(int hhhh = 0; hhhh <= 0xFFFF; hhhh++)
    {
        // For hiword hhhh, calculate integer value for loword of 0000 and FFFF.
        int hhhh0000 = (unchecked(hhhh * 0x10000));  // wrap around on negatives
        int hhhhFFFF = hhhh0000 + 0xFFFF;
        // How many decimal digits for each?
        int digits0000 = hhhh0000.Digits_IfChain();
        int digitsFFFF = hhhhFFFF.Digits_IfChain();
        // If same number of decimal digits, we know that when we see that hiword
        // we don't have to look at the loword to know the right answer.
        if(digits0000 == digitsFFFF)
        {
            _hhhhXXXXdigits[hhhh] = (sbyte)digits0000;
        }
        else
        {
            bool negative = hhhh >= 0x8000;
            // Calculate 10, 100, 1000, 10000 etc
            int tenToThePower = (int)Math.Pow(10, (negative ? digits0000 : digitsFFFF) - 1);
            // Calculate the loword of the 10^n value.
            ushort lowordSplit = unchecked((ushort)tenToThePower);
            if(negative)
                lowordSplit = unchecked((ushort)(2 + (ushort)~lowordSplit));
            // Store the split point and digits into these arrays
            _lowordSplits[b] = lowordSplit;
            _lowordSplitDigitsLT[b] = (sbyte)digits0000;
            _lowordSplitDigitsGE[b] = (sbyte)digitsFFFF;
            // Store the minus of the array index into the digits lookup. We look for
            // minus values and use these to trigger using the split points logic.
            _hhhhXXXXdigits[hhhh] = (sbyte)(-b);
            b++;
        }
    }
}
private static void precomputePositiveLo16()
{
    for(int i = 0; i <= 9; i++)
        _0000llll[i] = 1;
    for(int i = 10; i <= 99; i++)
        _0000llll[i] = 2;
    for(int i = 100; i <= 999; i++)
        _0000llll[i] = 3;
    for(int i = 1000; i <= 9999; i++)
        _0000llll[i] = 4;
    for(int i = 10000; i <= 65535; i++)
        _0000llll[i] = 5;
}
private static void precomputeNegativeLo16()
{
    for(int i = 0; i <= 9; i++)
        _FFFFllll[65536 - i] = 1;
    for(int i = 10; i <= 99; i++)
        _FFFFllll[65536 - i] = 2;
    for(int i = 100; i <= 999; i++)
        _FFFFllll[65536 - i] = 3;
    for(int i = 1000; i <= 9999; i++)
        _FFFFllll[65536 - i] = 4;
    for(int i = 10000; i <= 65535; i++)
        _FFFFllll[65536 - i] = 5;
}
public static int Digits_LookupTable(this int n)
{
    // Split input into low word and high word.
    ushort l = unchecked((ushort)n);
    ushort h = unchecked((ushort)(n >> 16));
    // If the hiword is 0000 or FFFF we have precomputed tables for these.
    if(h == 0x0000)
    {
        return _0000llll[l];
    }
    else if(h == 0xFFFF)
    {
        return _FFFFllll[l];
    }
    // In most cases the hiword will tell us the number of decimal digits.
    sbyte digits = _hhhhXXXXdigits[h];
    // We put a positive number in this lookup table when
    // hhhh0000 .. hhhhFFFF all have the same number of decimal digits.
    if(digits > 0)
        return digits;
    // Where the answer is different for hhhh0000 to hhhhFFFF, we need to
    // look up in a separate array to tell us at what loword the change occurs.
    var splitIndex = (sbyte)(-digits);
    ushort lowordSplit = _lowordSplits[splitIndex];
    // Pick the correct answer from the relevant array, depending whether
    // our loword is lower than the split point or greater/equal. Note that for
    // negative numbers, the loword is LOWER for MORE decimal digits.
    if(l < lowordSplit)
        return _lowordSplitDigitsLT[splitIndex];
    else
        return _lowordSplitDigitsGE[splitIndex];
}
**Binary search version**
c#
        public static int Digits_BinarySearch(this int n)
        {
            if(n >= 0)
            {
                if(n <= 9999) // 0 .. 9999
                {
                    if(n <= 99) // 0 .. 99
                    {
                        return (n <= 9) ? 1 : 2;
                    }
                    else // 100 .. 9999
                    {
                        return (n <= 999) ? 3 : 4;
                    }
                }
                else // 10000 .. int.MaxValue
                {
                    if(n <= 9_999_999) // 10000 .. 9,999,999
                    {
                        if(n <= 99_999)
                            return 5;
                        else if(n <= 999_999)
                            return 6;
                        else
                            return 7;
                    }
                    else // 10,000,000 .. int.MaxValue
                    {
                        if(n <= 99_999_999)
                            return 8;
                        else if(n <= 999_999_999)
                            return 9;
                        else
                            return 10;
                    }
                }
            }
            else
            {
                if(n >= -9999) // -9999 .. -1
                {
                    if(n >= -99) // -99 .. -1
                    {
                        return (n >= -9) ? 1 : 2;
                    }
                    else // -9999 .. -100
                    {
                        return (n >= -999) ? 3 : 4;
                    }
                }
                else // int.MinValue .. -10000
                {
                    if(n >= -9_999_999) // -9,999,999 .. -10000
                    {
                        if(n >= -99_999)
                            return 5;
                        else if(n >= -999_999)
                            return 6;
                        else
                            return 7;
                    }
                    else // int.MinValue .. -10,000,000 
                    {
                        if(n >= -99_999_999)
                            return 8;
                        else if(n >= -999_999_999)
                            return 9;
                        else
                            return 10;
                    }
                }
            }
        }
        Stopwatch sw0 = new Stopwatch();
        sw0.Start();
        for(int i = 0; i < size; ++i) samples[i].Digits_BinarySearch();
        sw0.Stop();
        Console.WriteLine($"Binary-Search: {sw0.ElapsedMilliseconds} ms");
