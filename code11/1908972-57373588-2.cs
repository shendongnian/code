    static void Main()
    {
        var R = new RNGCryptoServiceProvider();
        var bytes = new Byte[8];
        for (int i = 0; i < 10_000; i++)
        {
            R.GetBytes(bytes);
            var ul = BitConverter.ToUInt64(bytes, 0) / (1 << 11);
            var d  = ul / (double)(1UL << 53);
            d *= uint.MaxValue;
            Console.WriteLine(d);
        }
    }
