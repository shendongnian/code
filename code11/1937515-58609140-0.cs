private async void button3_Click(object sender, EventArgs e)
{
    var progress = new Progress<int>(percent =>
    {
        progressBar1.Value = percent;
    });
    progressBar1.Value = 1;
    int value = 100;
    await DoSomeWork(value,progress);
}
public Task DoSomeWork(int iterations,IProgress<int> progress)
{
    for(int i=0;i<iterations;i++)
    {
        await Task.Run(()=>{
           DoSomethingReallySlow(i);
           progress.Report(i*100/iterations));
        });
    }
}
Check [Async in 4.5: Enabling Progress and Cancellation in Async APIs](https://devblogs.microsoft.com/dotnet/async-in-4-5-enabling-progress-and-cancellation-in-async-apis/) for an example of both progress reporting and cancellation
