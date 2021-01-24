    public static MyStruct Total(this List<MyStruct> source)
    {
        var locker = new object();
        var sum = new MyStruct();
        var options = new ParallelOptions() { MaxDegreeOfParallelism = 3 };
        Parallel.ForEach(Partitioner.Create(0, source.Count), options,
            localInit: () => new MyStruct(), body: (range, state, local) =>
        {
            for (int i = range.Item1; i < range.Item2; i++)
            {
                var x = source[i];
                local.PropA += x.PropA;
                local.PropB += x.PropB;
                local.PropC += x.PropC;
            }
            return local;
        }, localFinally: (localSum) =>
        {
            lock (locker)
            {
                sum.PropA += localSum.PropA;
                sum.PropB += localSum.PropB;
                sum.PropC += localSum.PropC;
            }
        });
        return sum;
    }
