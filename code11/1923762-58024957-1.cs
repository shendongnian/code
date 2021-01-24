static void Main(string[] args)
{
    var watcher = new FileSystemWatcher //
    {
        Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), //Set watching to MyDocuments folder
        InternalBufferSize = 32 * 1024, // set 32KB buffer size (it's a maximal size)
        Filter = "*", //Set filter to all file types
        NotifyFilter = NotifyFilters.FileName, //We need this notify type for watch creating files
        EnableRaisingEvents = true //Begin watcing
    };
    watcher.Created += (s, e) => //subscribe lambda to "created" event
    {
        Console.WriteLine($"{e.FullPath} created");
        Task.Delay(1000).Wait();
        try
        {
            File.Copy(e.FullPath, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "updated", $"{e.Name}-{Guid.NewGuid()}"));
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    };
    Console.ReadLine(); //waiting
}
I tested this code in a console application. When the application is running, try creating a file in the MyDocuments folder. The program will send a message about creating the files and copy them file in "updated" folder.
