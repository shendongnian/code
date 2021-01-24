    internal sealed class TestDisposingObject : TrackingDisposable
    {
        public Task Job0Async() => Track(async () =>
        {
            await Task.Delay(200);
            Console.WriteLine("Job0 done.");
        });
        public Task<string> Job1Async(int ms) => Track(async () =>
        {
            await Task.Delay(ms);
            return "Job1 done.";
        });
        protected override void FinishDispose()
        => Console.WriteLine("Disposed.");
    }
