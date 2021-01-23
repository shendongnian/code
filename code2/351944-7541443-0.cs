    public class Hello
    {
        BigInteger X {get; set;}
        public Hello(BigInteger x)
        {
            X = x;
        }
        public Hello()
        {
            X = new BigInteger(0);
        }
    }
