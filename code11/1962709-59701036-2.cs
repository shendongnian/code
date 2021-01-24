    static void Main(string[] args)
    {
        var astr=Task.Run(async () =>
        {
           return await File.ReadAllTextAsync(@"C:\Users\User\Desktop\Test.txt");
        }).GetAwaiter().GetResult();
            
        Console.WriteLine(astr);
     }
