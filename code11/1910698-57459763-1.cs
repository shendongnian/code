    void Main()
    {
        // output is 0xB4006F00B8007300E700500051005D002800C2004600120026206100
        Console.WriteLine(BytesToHex(Encoding.GetEncoding("utf-16").GetBytes("´o¸sçPQ](ÂF\u0012…a")));
    }
    
    public static string BytesToHex(byte[] bytes)
    {
        // whatever way to convert bytes to hex
        return "0x" + BitConverter.ToString(bytes).Replace("-", "");
    }
