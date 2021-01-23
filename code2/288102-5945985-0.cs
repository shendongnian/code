    public struct UnsignedBigInteger
    {
        private BigInteger value;
        private UnsignedBigInteger(BigInteger n) { value = n; }
        public UnsignedBigInteger(uint n) { value = new BigInteger(n); }
        // ... other constructors ...
        public static UnsignedBigInteger operator+(UnsignedBigInteger lhs, UnsignedBigInteger rhs)
        {
            return new UnsignedBigInteger(lhs.value + rhs.value);
        }
        public static UnsignedBigInteger operator-(UnsignedBigInteger lhs, UnsignedBigInteger rhs)
        {
            var result = lhs.value - rhs.value;
            if (result < BigInteger.Zero) throw new InvalidOperationException("value out of range");
            return new UnsignedBigInteger(result);
        }
        // ... other operators ...
    }
