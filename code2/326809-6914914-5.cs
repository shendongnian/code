    static void Main(string[] args)
    {
        // I also tried a real cloud storage account. Same result.
        var container = CloudStorageAccount.DevelopmentStorageAccount.CreateCloudBlobClient().GetContainerReference("testcontainer");
        container.CreateIfNotExist();
        var blob = container.GetBlobReference("testblob.txt");
        using (var input = File.OpenRead(@"testblob.txt")) //5000000 bytes
        using (var output = blob.OpenWrite())
        {
            input.CopyTo(output);
        }
        var source = blob.OpenRead();
        int BUFFER_SIZE = 65536;
        byte[] buffer = new byte[BUFFER_SIZE];
        int bytesRead;
        int bytesCopied = 0;
        do
        {
            bytesRead = source.Read(buffer, 0, BUFFER_SIZE);
            bytesCopied += bytesRead;
        } while (bytesRead > 0);
        Console.WriteLine(bytesCopied); // prints 5000000
    }
