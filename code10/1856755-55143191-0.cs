public static void Main(string[] args)
{
    IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", false, true)
        .Build();
    var fileName = args[0];
    var path = $"{config["zipPath"]}\\{fileName}";
    string extractPath = @"c:\users\exampleuser\extract";
	
    byte[] zipBytes = Convert.FromBase64String(args[1]);
    using(var memoryStream = new MemoryStream(zipBytes))
    {
        using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Read))
        {
            archive.ExtractToDirectory(extractPath);
        }
        ZipFile.CreateFromDirectory(extractPath, path);
   }
}
