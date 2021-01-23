    var cts = new CancellationTokenSource();
    var rnd = new ThreadLocal<Random>(() => new Random());
    var q = Enumerable.Range(0, 11).Select(x => x).AsParallel()
        .WithCancellation(cts.Token).WithMergeOptions( ParallelMergeOptions.NotBuffered).WithDegreeOfParallelism(10).AsUnordered()
        .Where(i => i % 2 == 0 )
        .Select( i =>
        {
            return Task.Factory.StartNew(() =>
            {
            if( i == 0 )
                Thread.Sleep(3000);
            else
                Thread.Sleep(rnd.Value.Next(50, 100));
            return string.Format("dat {0}", i).Dump();
            });
        });
    cts.CancelAfter(5000);
    // returns as soon as the tasks are created
    var ts = q.ToArray();
    // wait till the first task finishes
    var idx = Task.WaitAny( ts );
    ts[idx].Result.Dump("res");
    
This is probably a terrible way to do it.  Since the actual work of the PLINQ query is just a very fast Task.Factory.StartNew, it's pointless to use PLINQ at all.  A simple  .Select( i => Task.Factory.StartNew( ...  on the IEnumerable is cleaner and probably faster.
