    static void Main(string[] args)
    {
        System.OperatingSystem osInfo = System.Environment.OSVersion;
        Console.WriteLine(osInfo.Platform);
        Console.WriteLine(osInfo.Version);
        Console.WriteLine(osInfo.ServicePack);
        Console.WriteLine(osInfo.VersionString);
    }
