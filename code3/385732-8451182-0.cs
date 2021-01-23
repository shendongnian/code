    static class Shifter
    {
        public static byte[] ShiftLeft(this byte[] array, int n)
        {
            var a = array.Select(x => (byte)(x >> 8 - n % 8)).Concat(new byte[(7 + n) / 8]).Select((x, i) => new Tuple<int, byte>(i - (n % 8 == 0 ? 0 : 1), x));
            var b = array.Select(x => (byte)(x << n % 8)).Concat(new byte[n / 8]).Select((x, i) => new Tuple<int, byte>(i, x));
            return (from x in a 
                    join y in b on x.Item1 equals y.Item1 into yy
                    from y in yy.DefaultIfEmpty()
                    select (byte)(x.Item2 | (y == null ? 0 : y.Item2))).ToArray();
        }
        public static byte[] ShiftRight(this byte[] array, int n)
        {
            return (new byte[n/8]).Concat(ShiftLeft(array, (8 - (n%8))%8)).ToArray();
        }
    }
