    class Stuff
    {
        int Id { get; }
    }
    public class GetStuff
    {
        async Task<Stuff> GetStuffById(int id) => throw new NotImplementedException();
        async Task GetLotsOfStuff(IEnumerable<int> ids)
        {
            //var bagOfStuff = new ConcurrentBag<Stuff>();
            var options = new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = 5,
                EnsureOrdered = false
            };
            var processor = new TransformBlock<int, Stuff>(id => GetStuffById(id), options);
            var handler = new ActionBlock<Stuff>(s => throw new NotImplementedException());
            processor.LinkTo(handler, new DataflowLinkOptions() { PropagateCompletion = true });
            foreach (int id in ids)
            {
                processor.Post(id);
            }
            processor.Complete();
            await handler.Completion;
        }
    }
