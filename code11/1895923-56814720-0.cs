    class Program
        {
            static void Main(string[] args)
            {
                using (var tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(60))) // See(the remark section): https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtokensource.-ctor?view=netframework-4.8#System_Threading_CancellationTokenSource__ctor_System_TimeSpan_
                {
                    try
                    {
                        new Object2().Run(tokenSource.Token).GetAwaiter().GetResult(); // <- should throw OperationCanceledException 
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }  
    class Object2
    {
        public Task Run(CancellationToken token)
        {
            return Task.Run(() =>
            {
                // Do your logic in o2.Run()
                // Assume o2.Run() takes 70 seconds to finish
                Thread.Sleep(70000);
                token.ThrowIfCancellationRequested();
            }, token);
        }
        public Task<T> Run<T>(CancellationToken token)
        {
            return Task.Run(() =>
            {
                // Do your logic in o2.Run()
                // Assume o2.Run() takes 70 seconds to finish
                Thread.Sleep(70000);
                token.ThrowIfCancellationRequested();
                // you can return something else instead of default(T);
                return default(T);
            }, token);
        }
    }
    
    class Object1 {}
