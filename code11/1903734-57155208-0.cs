    using System.Linq;
    using System.Threading.Tasks;
    /// <summary>
    /// Await all files in a list of paths to download
    /// </summary>
    public async Task DownloadFilesAsync(IWebClient client, IEnumerable<string> filePaths) 
    {
        var downloadTasks = filePaths
            .Select(f => DownloadFileAsync(client, f))
            .ToArray();
        // if any fails, we return that an error occurred.  If you prefer to let "some" of
        // those downloads fail, just move the try/catch into the individual file download 
        // method below.
        try {
            // wait for all to complete
            await Task
                .WhenAll(downloadTasks)
                .ConfigureAwait(false);
            
            return Task.CompletedTask;
        } catch (Exception e) {
            // I just made this up as an example; find the right type 
            // of result using intellisense in your IDE
            return Task.ErroredTask(e);
        }
    }
    /// <summary>
    /// Await a single file download
    /// </summary>
    public async Task DownloadFileTaskAsync(IWebClient client, string filePath) 
    {
        // set up request in the client, etc
        var url = "http://example.com";
        return await client
            .DownloadFile(url, filePath)
            .ConfigureAwait(false);
    }
