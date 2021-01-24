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
Method to call the executable.
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
Method which calls the above method
private static void PrimeImageCache(IReadOnlyCollection<string> urls) {
    var distinctUrls = urls.Distinct().ToList();
    const int concurrentBatches = 20;
    const int batchSize = 15;
    var processes = new List<Process>(concurrentBatches);
    foreach (var batch in distinctUrls.FormIntoBatches(batchSize)) {
        processes.Add(CreateProcess(batch));
        while (processes.Count >= concurrentBatches) {
            Thread.Sleep(500);
            for (var i = 0; i < processes.Count; i++) {
                var process = processes[i];
                if (process.HasExited) {
                    processes.Remove(process);
                }
            }
        }
    }
    while (processes.Count > 0) {
        Thread.Sleep(500);
        for (var i = 0; i < processes.Count; i++) {
            var process = processes[i];
            if (process.HasExited) {
                processes.Remove(process);
            }
        }
    }
}
The separate executable and method that calls it are pretty straightforward. I would like to explain some nuances in the final method. First, I initially tried using `foreach(var process in processes){process.WaitForExit();}` but that made it so that every process in the batch had to finish before I could launch a new one. It also caused the CPU to spike to 100% (I guess internally it does a near-empty loop to see if the process is finished). So, I "rolled my own" as seen in the first `while` loop.
Second, I had to add the final `while` loop to make sure that the processes that were still running after I queued up the final batch in the previous `foreach()` had a chance to finish.
Hope this helps someone else.
