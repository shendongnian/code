class Program
    {
        static async Task Main(string[] args)
        {
            var task = First();
            Console.WriteLine("End of main");
            await task;
        }
        static Task First()
        {
            return SecondAsync();
        }
        static async Task SecondAsync()
        {
            await ThirdAsync();
        }
        static async Task ThirdAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("Third");
        }
    }
This writes `End of main` before `Third`, proving that it is in fact asynchronous.
  [1]: https://blog.stephencleary.com/2016/12/eliding-async-await.html
