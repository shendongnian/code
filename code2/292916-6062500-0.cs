    static void Main(string[] args)
    {
        Console.WriteLine(ConfigurationManager.AppSettings("TestSettings"));
        Console.ReadLine();
        //Before hitting return I changed the value of TestSettings manually
        Console.WriteLine(ConfigurationManager.AppSettings("TestSettings"));
        Console.ReadLine();
    }
