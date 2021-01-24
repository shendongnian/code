    static void Main(string[] args)
    {
        string banner = PrintBanner("This is what's supposed to be printed.")
        Console.WriteLine(banner); 
        Console.ReadLine();
    }
    
    //PrintBanner now has a string parameter, 
    //thus when we call it in main, we can pass a string as an argument
    public static string PrintBanner(string message)
    {
        return message;
    }
