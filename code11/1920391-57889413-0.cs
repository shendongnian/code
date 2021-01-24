    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApp4
    {
        class Program
        {
            private static int Counter;
    
            private static async Task Main(string[] args)
            {
                await foreach (var value in PeriodicYield(SimpleGenerator, 1000))
                {
                    Console.WriteLine(
                        $"Time\"{DateTimeOffset.UtcNow}\", Value:{value}");
                }
            }
    
            private static async Task<int> SimpleGenerator()
            {
                await Task.Delay(1500);
                return Interlocked.Increment(ref Counter);
            }
    
            private static async IAsyncEnumerable<T> PeriodicYield<T>(
                Func<Task<T>> generatorAsync,
                int periodMilliseconds,
                CancellationToken token = default)
            {
                var last = DateTimeOffset.UtcNow;
    
                while (!token.IsCancellationRequested)
                {
                    var nextValue = await generatorAsync();
    
                    var now = DateTimeOffset.UtcNow;
                    var gap = (int)(now - last).TotalMilliseconds;
                    var head = gap % periodMilliseconds;
                    var tail = periodMilliseconds - head;
                    var next = now.AddMilliseconds(tail);
    
                    while (next >= DateTimeOffset.Now)
                    {
                        var delay = (int)(next - DateTimeOffset.Now).TotalMilliseconds;
                        delay = (int)Math.Max(1.0, delay * 0.1);
                        await Task.Delay(delay, token);
                    }
    
                    if (!token.IsCancellationRequested)
                    {
                        yield return nextValue;
                        last = DateTimeOffset.UtcNow;
                    }
                }
            }
        }
    }
