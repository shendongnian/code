    public static void Main(string[] args)
    {
        string banner;
        PrintBanner(banner = "This is whats supposed to be printed.");
    }
    public static void PrintBanner(string text)
    {
        // The text variable contains "This is whats supposed to be printed." now.
        // You can perform whatever operations you want with it within this scope,
        // but it won't alter the text the banner variable contains.
    }
