    public static void Main(string[] args)
    {
        string banner;
        banner = PrintBanner("This is whats supposed to be printed.");
    }
    public static string PrintBanner(string text)
    {
        Console.Write(text);
        return text;
    }
