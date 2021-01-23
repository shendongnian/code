    public static void ValidateBigIntForUnsigned(BigInteger bigInteger)
    {
       if(bigInteger.Sign < 0)
           throw new Exception("Only unsigned numbers are allowed!");
    }
