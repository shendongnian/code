    void Main()
    {
        string inputChars = "0123456789ABCDEF";
        string replacementChars = "ABCDEFGHIJKLMNOP";
        
        byte[] r = Convert.FromBase64String("XFEWtnopccImhpHTzGeoeXBg4ws=");
        string c = BitConverter.ToString(r);
        
        string result = new String(c.Where(ch => inputChars.Contains(ch))
                                    .Select(ch => replacementChars[inputChars.IndexOf(ch)])
                                    .ToArray());
        
        Console.WriteLine(result.ToLower());
    }
