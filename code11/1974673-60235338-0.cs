using System;
using System.Linq;
using System.Numerics;
public static class LargestSeriesProduct
{
    static BigInteger getAnswer(string d, int s) => Enumerable.Range(0, d.Length - s + 1)
        .Select(i => d.Substring(i, s))
        .Select(n => n.Aggregate(new BigInteger(1), (current, t) => current * (t - '0')))
        .OrderByDescending(x => x)
        .First();
    public static long GetLargestProduct(string digits, int span)
    {
        if (span > digits.Length)
        {
            throw new ArgumentException("Rejects_span_longer_than_string_length");
        }
        else if (span == 0 || digits.Length == 0)
        {
            return 1;
        }
        else if (span == 1 && digits.Length == 0)
        {
            throw new ArgumentException("Rejects_empty_string_and_nonzero_span");
        }
        else if (span < 0)
        {
            throw new ArgumentException("Rejects_negative_span");
        }
        else if (!digits.All(char.IsDigit))
        {
            throw new ArgumentException("Rejects_invalid_character_in_digits");
        }
        else if (digits.All(c => c == '0'))
        {
            return 0;
        }
        else
        {
            return (int)getAnswer(digits, span);
        }
    }
}
