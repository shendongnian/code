    class Program 
    {
        static async Task Main()
        {
            try
            {
                await using (var d = new D())
                {
                    throw new ArgumentException("I'm inside using");
                }
            }
            catch (AggregateException ex)
            {
                ex.Handle(inner =>
                {
                    if (inner is Exception)
                    {
                        Console.WriteLine(e.Message);
                    }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    
    class D : IAsyncDisposable
    {
        public async ValueTask DisposeAsync()
        {
            await Task.Delay(1);
            throw new Exception("I'm inside dispose");
        }
    }
