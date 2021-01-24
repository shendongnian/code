    class SomeTaskProcessor {
        private HttpClient http = new HttpClient() {
            BaseAddress = new Uri("http://localhost:49890/api/values")
        };
        public int Id { get; private set; }
        public SomeTaskProcessor(int id) { Id = id; }
        public async Task ExecuteLongRunningProcessThatReadsDbAndCreatesSomeNewRecords() {
            Console.WriteLine($"Starting ID {Id}");
            var response = await http.GetAsync(String.Empty);
            Console.WriteLine($"Completing ID {Id}. Response status code is {response.StatusCode}");
        }
    }
    class Program {
        static async Task Main(string[] args) {
            int[] ids = Enumerable.Range(1, 100).ToArray();;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var tasks = ids.Select(id => {
                var processor = new SomeTaskProcessor(id);
                return processor.ExecuteLongRunningProcessThatReadsDbAndCreatesSomeNewRecords();
            }).ToArray();
            await Task.WhenAll(tasks);
            // ~8 seconds
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed.ToString());
        }
    }
