    using System;
    using System.Threading;
    using System.Threading.Tasks;
    ...
    var cts = new CancellationTokenSource();
    var task = Task.Run(() => { while (true) { } });
    Parallel.Invoke(() =>
    {
        task.Wait(cts.Token);
    }, () =>
    {
        Thread.Sleep(1000);
        cts.Cancel();
    });
