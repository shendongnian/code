    class Program
    {
        static void Main(string[] args)
        {
            foreach (var message in GetMessages())
            {
                Console.WriteLine(message);
            }
        }
        // Parallel yield
        private static IEnumerable<string> GetMessages()
        {
            int total = 0;
            bool completed = false;
            var batches = Enumerable.Range(1, 100).Select(i => new Computer() { Id = i });
            var qu = new ConcurrentQueue<Computer>();
            Task.Run(() =>
            {
                try
                {
                    Parallel.ForEach(batches,
                        () => 0,
                        (item, loop, subtotal) =>
                        {
                            Thread.Sleep(1000);
                            qu.Enqueue(item);
                            return subtotal + 1;
                        },
                        result => Interlocked.Add(ref total, result));
                }
                finally
                {
                    completed = true;
                }
            });
            int current = 0;
            while (current < total || !completed)
            {
                SpinWait.SpinUntil(() => current < total || completed);
                if (current == total) yield break;
                current++;
                qu.TryDequeue(out Computer computer);
                yield return $"Completed {computer.Id}";
            }
        }
    }
    public class Computer
    {
        public int Id { get; set; }
    }
