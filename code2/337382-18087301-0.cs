    static void Main()
    {
        float tempVar = -27.25f;
        int intBits = BitConverter.ToInt32(BitConverter.GetBytes(tempVar), 0);
        string input = Convert.ToString(intBits, 2);
        input = input.PadLeft(32, '0');
        string sign = input.Substring(0, 1);
        string exponent = input.Substring(1, 8);
        string mantissa = input.Substring(9, 23);
        Console.WriteLine();
        Console.WriteLine("Sign = {0}", sign);
        Console.WriteLine("Exponent = {0}", exponent);
        Console.WriteLine("Mantissa = {0}", mantissa);
    }
