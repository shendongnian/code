    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace AsynchronouslyDelayedEnumerable
    {
        internal class Program
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
    
            /// <summary>
            /// Yield a result periodically.
            /// </summary>
            /// <param name="generatorAsync">Some generator delegate.</param>
            /// <param name="periodMilliseconds">
            /// The period in milliseconds at which results should be yielded.
            /// </param>
            /// <param name="token">A cancellation token.</param>
            /// <typeparam name="T">The type of the value to yield.</typeparam>
            /// <returns>A sequence of values.</returns>
            private static async IAsyncEnumerable<T> PeriodicYield<T>(
                Func<Task<T>> generatorAsync,
                int periodMilliseconds,
                CancellationToken token = default)
            {
                // Set up a starting point.
                var last = DateTimeOffset.UtcNow;
    
                // Continue until cancelled.
                while (!token.IsCancellationRequested)
                {
                    // Get the next value.
                    var nextValue = await generatorAsync();
    
                    // Work out the end of the next whole period.
                    var now = DateTimeOffset.UtcNow;
                    var gap = (int)(now - last).TotalMilliseconds;
                    var head = gap % periodMilliseconds;
                    var tail = periodMilliseconds - head;
                    var next = now.AddMilliseconds(tail);
    
                    // Wait for the end of the next whole period with
                    // logarithmically shorter delays. 
                    while (next >= DateTimeOffset.Now)
                    {
                        var delay = (int)(next - DateTimeOffset.Now).TotalMilliseconds;
                        delay = (int)Math.Max(1.0, delay * 0.1);
                        await Task.Delay(delay, token);
                    }
    
                    // Check if cancelled.
                    if (token.IsCancellationRequested)
                    {
                        continue;
                    }
    
                    // return the value and update the last time.
                    yield return nextValue;
                    last = DateTimeOffset.UtcNow;
                }
            }
        }
    }
