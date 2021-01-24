    public static string ToDecimalStringParallel(this BigInteger value)
    {
        if (value == 0) return "0";
        var digits = 10000;
        var divider = BigInteger.Pow(10, digits);
        var remainders = new BlockingCollection<BigInteger>();
        var parts = new ConcurrentStack<string>();
        var task = Task.Run(() =>
        {
            foreach (var remainder in remainders.GetConsumingEnumerable())
            {
                parts.Push(BigInteger.Abs(remainder).ToString().PadLeft(digits, '0'));
            }
        });
        while (true)
        {
            BigInteger remainder;
            value = BigInteger.DivRem(value, divider, out remainder);
            if (value != 0)
            {
                remainders.Add(remainder);
            }
            else
            {
                remainders.CompleteAdding();
                task.Wait();
                parts.Push(remainder.ToString());
                break;
            }
        }
        return String.Join("", parts);
    }
