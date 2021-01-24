    static void Main(string[] args)
    {
        string banner = PrintBanner("This is what's supposed to be printed.")
        Console.WriteLine(banner); 
        Console.ReadLine();
    }
    
    //PrintBanner now has a string parameter named message (you can name it 
    //whatever you want, but in the method in order to access that parameter, the 
    //names have to match), thus when we call it in main, we can pass a string as 
    //an argument
    public static string PrintBanner(string message)
    {
        return message;
    }
