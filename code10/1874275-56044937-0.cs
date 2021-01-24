 c#
class Program {
    static void Main(string[] args) {
        var tasks = new List<Task>(args.Length);
        foreach (var url in args) {
            tasks.Add(Task.Run(async () => await SendRequest(url)));
        }
        Task.WaitAll(tasks.ToArray());
    }
    private static async Task SendRequest(string url) {
        var myWebRequest = WebRequest.Create(url);
        myWebRequest.Method = "HEAD";
        var foo = await myWebRequest.GetResponseAsync();
        foo.Dispose();
    }
}
Method to call the stub
private static Process CreateProcess(IEnumerable<string> urls)
{
    var args = urls.Aggregate("", (current, url) => current + url + " ");
    var start = new ProcessStartInfo();
    start.Arguments = args;
    start.FileName = "ImageCachePrimer.exe";
    start.WindowStyle = ProcessWindowStyle.Hidden;
    start.CreateNoWindow = false;
    start.UseShellExecute = true;
    return Process.Start(start);
}
