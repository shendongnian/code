    static void Main(string[] args)
    {
        try
        {
            var result = combineFiles().Result;
        }
        catch (ArgumentException aex)
        {
            Console.WriteLine($"Caught ArgumentException: {aex.Message}");
        }
    }
    static async Task<bool> combineFiles()
    {
        List<Task> tasks = new List<Task>();
        string path = "C:\\Temp\\testfileread\\";
        Task<string> file1Read = ReadTextAsync(Path.Combine(path, "test1.txt"));
        Task<string> file2Read = ReadTextAsync(Path.Combine(path, "test2.txt"));
        Task<string> file3Read = ReadTextAsync(Path.Combine(path, "test3.txt"));
        await Task.WhenAll(file1Read, file2Read, file3Read);
        string text1 = await file1Read;
        string text2 = await file2Read;
        string text3 = await file3Read;
        await WriteTextAsync(Path.Combine(path, "result.txt"), text1 + text2 + text3);
        Console.WriteLine("Finished combining files");
        Console.ReadLine();
        return true;
    }
    private static async Task<string> ReadTextAsync(string filePath)
    {
        using (var reader = File.OpenText(filePath))
        {
            var fileText = await reader.ReadToEndAsync();
            return fileText;
        }
    }
    private static async Task WriteTextAsync(string filePath, string value)
    {
        using (StreamWriter writer = File.CreateText(filePath))
        {
            await writer.WriteAsync(value);
        }
    }
