c#
// Subscribe to OutputData
Observable.FromEventPattern<DataReceivedEventArgs>(process, nameof(Process.OutputDataReceived))
    .Subscribe(
        eventPattern => output.AppendLine(eventPattern.EventArgs.Data),
        exception => error.AppendLine(exception.Message)
    ).DisposeWith(disposables);
`FromEventPattern` allows us to map distinct occurrences of an event to a unified stream (aka observable). This allows us to handle the events in a pipeline (with LINQ-like semantics). The `Subscribe` overload used here is provided with an `Action<EventPattern<...>>` and an `Action<Exception>`. Whenever the observed event is raised, its `sender` and `args` will be wrapped by `EventPattern` and pushed through the `Action<EventPattern<...>>`. When an exception is raised in the pipeline, `Action<Exception>` is used.
One of the drawbacks of the `Event` pattern, clearly illustrated in this use case (and by all the workarounds in the referenced post), is that it's not apparent when / where to unsubscribe the event handlers.
With Rx we get back an `IDisposable` when we make a subscription. When we dispose of it, we effectively end the subscription. With the addition of the `DisposeWith` extension method (borrowed from [RxUI](https://github.com/reactiveui/ReactiveUI/blob/master/src/ReactiveUI/Mixins/DisposableMixins.cs)), we can add multiple `IDisposable`s to a `CompositeDisposable` (named `disposables` in the code samples). When we're all done, we can end all subscriptions with one call to `disposables.Dispose()`.
To be sure, there's nothing we can do with Rx, that we wouldn't be able to do with vanilla .NET. The resulting code is just a lot easier to reason about, once you've adapted to the functional way of thinking.
c#
public static void ExecuteScriptRx(string path, int processTimeOutMilliseconds, out string logs, out bool success, params string[] args)
{
    StringBuilder output = new StringBuilder();
    StringBuilder error = new StringBuilder();
    using (var process = new Process())
    using (var disposables = new CompositeDisposable())
    {
        process.StartInfo = new ProcessStartInfo
        {
            WindowStyle = ProcessWindowStyle.Hidden,
            FileName = "powershell.exe",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            Arguments = $"-ExecutionPolicy Bypass -File \"{path}\"",
            WorkingDirectory = Path.GetDirectoryName(path)
        };
        if (args.Length > 0)
        {
            var arguments = string.Join(" ", args.Select(x => $"\"{x}\""));
            process.StartInfo.Arguments += $" {arguments}";
        }
        output.AppendLine($"args:'{process.StartInfo.Arguments}'");
        // Raise the Process.Exited event when the process terminates.
        process.EnableRaisingEvents = true;
        // Subscribe to OutputData
        Observable.FromEventPattern<DataReceivedEventArgs>(process, nameof(Process.OutputDataReceived))
            .Subscribe(
                eventPattern => output.AppendLine(eventPattern.EventArgs.Data),
                exception => error.AppendLine(exception.Message)
            ).DisposeWith(disposables);
        // Subscribe to ErrorData
        Observable.FromEventPattern<DataReceivedEventArgs>(process, nameof(Process.ErrorDataReceived))
            .Subscribe(
                eventPattern => error.AppendLine(eventPattern.EventArgs.Data),
                exception => error.AppendLine(exception.Message)
            ).DisposeWith(disposables);
        var processExited =
            // Observable will tick when the process has gracefully exited.
            Observable.FromEventPattern<EventArgs>(process, nameof(Process.Exited))
                // First two lines to tick true when the process has gracefully exited and false when it has timed out.
                .Select(_ => true)
                .Timeout(TimeSpan.FromMilliseconds(processTimeOutMilliseconds), Observable.Return(false))
                // Force termination when the process timed out
                .Do(exitedSuccessfully => { if (!exitedSuccessfully) { try { process.Kill(); } catch {} } } );
        // Subscribe to the Process.Exited event.
        processExited
            .Subscribe()
            .DisposeWith(disposables);
        // Start process(ing)
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        // Wait for the process to terminate (gracefully or forced)
        processExited.Take(1).Wait();
        logs = output + Environment.NewLine + error;
        success = process.ExitCode == 0;
    }
}
We already discussed the first part, where we map our events to observables, so we can jump straight to the meaty part. Here we assign our observable to the `processExited` variable, because we want to use it more than once.
First, when we activate it, by calling `Subscribe`. And later on when we want to 'await' its first value.
c#
var processExited =
    // Observable will tick when the process has gracefully exited.
    Observable.FromEventPattern<EventArgs>(process, nameof(Process.Exited))
        // First two lines to tick true when the process has gracefully exited and false when it has timed out.
        .Select(_ => true)
        .Timeout(TimeSpan.FromMilliseconds(processTimeOutMilliseconds), Observable.Return(false))
        // Force termination when the process timed out
        .Do(exitedSuccessfully => { if (!exitedSuccessfully) { try { process.Kill(); } catch {} } } );
// Subscribe to the Process.Exited event.
processExited
    .Subscribe()
    .DisposeWith(disposables);
// Start process(ing)
...
// Wait for the process to terminate (gracefully or forced)
processExited.Take(1).Wait();
One of the problems with OP is that it assumes `process.WaitForExit(processTimeOutMiliseconds)` will terminate the process when it times out. From [MSDN](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.process.waitforexit#System_Diagnostics_Process_WaitForExit_System_Int32_): 
> Instructs the [Process](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.process?view=netframework-4.8) component to wait the specified number of milliseconds for the associated process to exit.
Instead, when it times out, it merely returns control to the current thread (i.e. it stops blocking). You need to manually force termination when the process times out. To know when time out has occurred, we can map the `Process.Exited` event to a `processExited` observable for processing. This way we can prepare the input for the `Do` operator.
The code is pretty self-explanatory. If `exitedSuccessfully` the process will have terminated gracefully. If not `exitedSuccessfully`, termination will need to be forced. Note that `process.Kill()` is executed asynchronously, ref [remarks](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.process.kill#remarks). However, calling `process.WaitForExit()` right after will open up the possibility for deadlocks again. So even in the case of forced termination, it's better to let all disposables be cleaned up when the `using` scope ends, as the output can be considered interrupted / corrupted anyway.
The `try catch` construct is reserved for the exceptional case (no pun intended) where you've aligned `processTimeOutMilliseconds` with the actual time needed by the process to complete. In other words, a race condition occurs between the `Process.Exited` event and the timer. The possibility of this happening is again magnified by the asynchronous nature of `process.Kill()`. I've encountered it once during testing.
---------------------
For completeness, the `DisposeWith` extension method.
c#
/// <summary>
/// Extension methods associated with the IDisposable interface.
/// </summary>
public static class DisposableExtensions
{
    /// <summary>
    /// Ensures the provided disposable is disposed with the specified <see cref="CompositeDisposable"/>.
    /// </summary>
    public static T DisposeWith<T>(this T item, CompositeDisposable compositeDisposable)
        where T : IDisposable
    {
        if (compositeDisposable == null)
        {
            throw new ArgumentNullException(nameof(compositeDisposable));
        }
        compositeDisposable.Add(item);
        return item;
    }
}
