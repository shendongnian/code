    public static string ConvertBigBinaryToHex(string bigBinary)
    {
        BigInteger bigInt = BigInteger.Zero;
        int exponent = 0;
    
        for (int i = bigBinary.Length - 1; i >= 0; i--, exponent++)
        {
    	    if (bigBinary[i] == '1')
    	        bigInt += BigInteger.Pow(2, exponent);
        }
    
        return bigInt.ToString("X");
    }
