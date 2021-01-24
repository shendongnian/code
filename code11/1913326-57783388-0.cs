    class TaskTest
    {
        public async void Start()
        {
            await (
                (await One().ContinueWith(x => Task.WhenAll(Two(), Three())))
                .ContinueWith(x=> Four()));
        }
        private async Task One()
        {
            await Task.Delay(5000);
            Console.WriteLine("1");
            throw new Exception();
        }
        private async Task Two()
        {
            await Task.Delay(2000);
            Console.WriteLine("2");
            throw new Exception();
        }
        private async Task Three()
        {
            await Task.Delay(3000);
            Console.WriteLine("3");
            throw new Exception();
        }
        private async Task Four()
        {
            await Task.Delay(1000);
            Console.WriteLine("4");
            throw new Exception();
        }
    }
