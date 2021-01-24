    public class AssertSynchronousItemHandler : IItemHandler
    {
        private volatile int concurrentWork = 0;
        public List<Item> Items = new List<Item>();
        public Task PerformIndividualWork(Item item) =>
            Task.Run(() => {
                var result = Interlocked.Increment(ref concurrentWork);
                if (result != 1) {
                    throw new Exception($"Expected 1 work item running at a time, but got {result}");
                }
                Items.Add(item);
                var after = Interlocked.Decrement(ref concurrentWork);
                if (after != 0) {
                    throw new Exception($"Expected 0 work items running once this item finished, but got {after}");
                }
            });
    }
