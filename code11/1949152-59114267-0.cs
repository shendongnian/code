      private static async Task Start()
        {
            Task<string> task = GetDataString();
            string result = await Process<string>(task);
            Console.WriteLine(result);
            Console.ReadLine();
        }
        public Task<string> GetDataString()
        {
            return new TaskFactory(TaskScheduler.Default).StartNew(() =>
            {
                Console.WriteLine("Executing");
                return "test";
            });
        }
        public async Task<T> Process<T>(Task<T> task)
        {
            Console.WriteLine("Before");
            var res = await task;
            Console.WriteLine("After");
            return res;
        }
