    Parallel.For(0, 10000000, () => new ThreadState(),
        (i, loopstate, threadstate) =>
    {
        ComplexDataSet data = GenerateData(i);
        threadstate.Add(data);
        return threadstate;
    }, threadstate => threadstate.Dispose());
    sealed class ThreadState : IDisposable
    {
        readonly IDisposable db;
        readonly Queue<ComplexDataSet> queue = new Queue<ComplexDataSet>();
        public ThreadState()
        {
            // initialize db with a private MongoDb connection.
        }
        public void Add(ComplexDataSet cds)
        {
            queue.Enqueue(cds);
            if(queue.Count == 100)
            {
                Commit();
            }
        }
        void Commit()
        {
            // db.Write(queue);
            queue.Clear();
        }
        public void Dispose()
        {
            try
            {
                if(queue.Count > 0)
                {
                    Commit();
                }
            }
            finally
            {
                db.Dispose();
            }
        }
    }
