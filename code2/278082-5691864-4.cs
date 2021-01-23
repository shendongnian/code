    public static string smallNumBigNumProduct(string a, string b)
    {
        // NOTE no error checking for bad input or possible overflow...
        BigInteger num1 = BigInteger.Zero;
        BigInteger num2 = BigInteger.Zero;
        bool convert1 = BigInteger.TryParse(a, out num1);
        bool convert2 = BigInteger.TryParse(b, out num2);
        return (convert1 && convert2) ? (num1*num2).ToString() : "Unable to convert";
    }
