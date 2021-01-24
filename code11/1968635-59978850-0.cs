WebClient Client;
public async Task<bool> download(string url, string to)
{
	TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
    Uri ur = new Uri(url);
    File.Delete(to);
    addAction("\nDownloading: " + url);
    createFile(to.Substring(0, to.IndexOf(".")), "", to.Substring(to.IndexOf(".") + 1));
    Client = new WebClient();
    Client.DownloadProgressChanged += OnDownloadProgressChanged;
    Client.DownloadFileCompleted += (d,e)=>{ tcs.SetResult(true);};
	 
    Client.DownloadFileAsync(ur, @"" + to);   
	return await tcs.Task;
}
Now you could use the method as
await download(url,filePath);
String curver = File.ReadAllText(filePath);
