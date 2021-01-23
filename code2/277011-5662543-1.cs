    public static string generator(string pesel, string varKlientID) { 
        // I have cut some code here to keep it short
        BigInteger convertedNumber;
        if (BigInteger.TryParse(mergedNumber , out convertedNumber))
        {
            BigInteger modulo = convertedNumber % 97;			
            // The rest of the method goes here...
        }
        else
        {
            // string could not be parsed to BigInteger; handle gracefully
        }
    }
    private static BigInteger MathMod(BigInteger a, BigInteger b)
    {
        return (BigInteger.Abs(a * b) + a) % b;
    }
