    class SomeTaskProcessor {
        private HttpClient http = new HttpClient() {
            BaseAddress = new Uri("http://localhost:49890/api/values")
        };
        public int Id { get; private set; }
        public SomeTaskProcessor(int id) { Id = id; }
        public void ExecuteLongRunningProcessThatReadsDbAndCreatesSomeNewRecords() {
            Console.WriteLine($"Starting ID {Id}. Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            var response = http.GetAsync(String.Empty).GetAwaiter().GetResult();
            Console.WriteLine($"Completing ID {Id}. Response status code is {response.StatusCode}. Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
    class Program {
        static void Main(string[] args) {
            int[] ids = Enumerable.Range(1, 100).ToArray();;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.ForEach(ids, id => {
                var processor = new SomeTaskProcessor(id);
                processor.ExecuteLongRunningProcessThatReadsDbAndCreatesSomeNewRecords();
            });
            // ~23 seconds
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed.ToString());
        }
    }
