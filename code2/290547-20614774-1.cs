    static void Main(string[] arg)
    {
        string ch = "(\xd808\xdd00汉语 or 漢語, Hànyǔ)";
        Console.WriteLine(ch.Substring(0, Math.Min(ch.Length, 10)));
        var enc = Encoding.UTF32.GetBytes(ch);
        string first10chars = Encoding.UTF32.GetString(enc, 0, Math.Min(enc.Length, 4 * 10));
        Console.WriteLine(first10chars);
        Console.ReadLine();
    }
