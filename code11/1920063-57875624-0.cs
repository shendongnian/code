    static async Task Main(string[] args)
    {
        // Dummy Azure cloud file
        var url = "https://idonthaveaurl.com";
        var cloudFile = new CloudFile(new Uri(url));
        // 1MB buffer
        byte[] buffer = new byte[1024 * 1024];
        var totalSize = 0;
        var bytesDownloaded = 0;
        var ms = new MemoryStream();
        // Asynchronous download operation
        do
        {
            // Download another 1MB chunk until we have the whole file
            bytesDownloaded = await cloudFile.DownloadToByteArrayAsync(buffer, 0);
            Console.WriteLine($"Downloaded {bytesDownloaded} more bytes of the file...");
            totalSize += bytesDownloaded;
            // Append the buffer to our in-memory stream
            ms.Write(buffer, 0, bytesDownloaded);
        } while (bytesDownloaded > 0);
        Console.WriteLine($"Download complete (total size = {totalSize}");
        // Now memorystream contains our file
        var bytes = ms.ToArray();
        
        // TODO: Do something with bytes
    }
