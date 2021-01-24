    static string DecodeWithoutLinq(string encoded)
    {
        char[] s = new char[encoded.Length];
        for (int i = 0; i < encoded.Length; i++)
        {
            char currentChar = encoded[i];
            if (char.IsLetter(currentChar))
                s[i] = (char)(encoded[i] + 10);
            else if (char.IsNumber(currentChar))
                s[i] = (char)('A' + (currentChar - '0'));
        }
        return string.Join("", s).ToLower();
    }
    static string DecodeWithLinq(string encoded)
    {
        return string.Join("", encoded.ToCharArray()
            .Select(s => char.IsLetter(s) ? (char)(s + 10) : (char)('A' + (s - '0')))).ToLower();
    }
    static void Main(string[] args)
    {
        byte[] r = Convert.FromBase64String("XFEWtnopccImhpHTzGeoeXBg4ws=");
        string c = BitConverter.ToString(r).Replace("-", string.Empty);
        string decodedString1 = DecodeWithoutLinq(c);
        string decodedString2 = DecodeWithLinq(c);
        Console.WriteLine(decodedString1);
        Console.WriteLine(decodedString2);
            
        Console.ReadKey();
    }
