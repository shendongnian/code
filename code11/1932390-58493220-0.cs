csharp
public void Test() {
    List<Task> tasks = new List<Task>();
    tasks.Add(Task.Run(() => {
        // your code here 
    }));
    tasks.Add(Task.Run(() =>
    {
        // your other parallel code here
    }));
    Task.WhenAll(tasks).Wait();
}
If your using a newer version of hangfire it supports async method for background jobs so you just change the last line to `await Task.WhenAll(tasks);`.
