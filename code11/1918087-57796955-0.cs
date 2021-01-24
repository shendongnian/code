    class SomeTaskProcessor
    {
        static Random rng = new Random();
        public int Id { get; private set; }
        public SomeTaskProcessor(int id) { Id = id; }
        public void ExecuteLongRunningProcessThatReadsDbAndCreatesSomeNewRecords()
        {
            Console.WriteLine($"Starting ID {Id}");
            System.Threading.Thread.Sleep(rng.Next(1000));
            Console.WriteLine($"Completing ID {Id}");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            int[] ids = Enumerable.Range(1, 100).ToArray();
    
            Parallel.ForEach(ids, id => {
                    var processor = new SomeTaskProcessor(id);
                    processor.ExecuteLongRunningProcessThatReadsDbAndCreatesSomeNewRecords();
            });
        }
    }
