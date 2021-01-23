    var cts = new CancellationTokenSource();
    var rnd = new ThreadLocal<Random>(() => new Random());
    var q = Enumerable.Range(0, 11).Select(x => x).AsParallel()
        .WithCancellation(cts.Token).WithMergeOptions( ParallelMergeOptions.NotBuffered).WithDegreeOfParallelism(10).AsUnordered()
        .Where(i => i % 2 == 0 )
        .Select( i =>
        {
            if( i == 0 )
                Thread.Sleep(3000);
            else
                Thread.Sleep(rnd.Value.Next(50, 100));
            return string.Format("dat {0}", i).Dump();
        });
    cts.CancelAfter(5000);
    var qu = new BlockingCollection<string>();
    // ForAll blocks until PLINQ query is complete
    Task.Factory.StartNew(() => q.ForAll( x => qu.Add(x) ));
    // get first result asap
    qu.Take().Dump("result");
    
