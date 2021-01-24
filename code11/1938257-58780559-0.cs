public class Worker
{
    public string Status { get; set; }
    public async Task DoWork(IProgress<string> progress)
    {
        for (int i = 0; i < 10000; i++)
        {
            Status = "Test" + i;
            progress.Report(Status);
            await Task.Delay(100);
        }
    }
}
2) You should make sure that your MainWindowViewModel was created.
I didn't understand what you try to do in this code, but with fixes, this code works fine.
**Your problem was in your DoWork method. This was done synchronously.**
