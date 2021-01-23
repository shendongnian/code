    public static class BigIntegerListExtensions
    {
        public static void Add(this IList<BigInteger> list,
            params byte[] value)
        {
            list.Add(new BigInteger(value));
        }
        public static void Add(this IList<BigInteger> list,
            string value)
        {
            list.Add(BigInteger.Parse(value));
        }
    }
    var bigNumbers = new List<BigInteger>
    {
        new BigInteger(1), // constructor BigInteger(int)
        2222222222L,       // implicit operator BigInteger(long)
        3333333333UL,      // implicit operator BigInteger(ulong)
        { 4, 4, 4, 4, 4, 4, 4, 4 },               // extension Add(byte[])
        "55555555555555555555555555555555555555", // extension Add(string)
    };
