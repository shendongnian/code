csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {
        await foreach (bool x in GetBoolsAsync())
        {
            Console.WriteLine(x);
        }
    }
    // Method to return an IAsyncEnumerable<T>. It doesn't
    // need the async modifier.
    static IAsyncEnumerable<bool> GetBoolsAsync() =>
        GetBools().ToAsyncEnumerable();
    // Regular synchronous iterator method.
    static IEnumerable<bool> GetBools()
    {
        yield return true;
        yield break;
    }
}
This complies with the interface (of using `IAsyncEnumerable<T>`) but allows a synchronous implementation, with no warnings. Note that the `async` modifier itself is *not* part of a method signature - it's an implementation detail. So a method specified in an interface as returning a `Task<T>`, `IAsyncEnumerable<T>` or whatever can be implemented with an async method, but doesn't have to be.
Of course for a simple example where you just want to return a single element, you could use `ToAsyncEnumerable` on an array, or the result of `Enumerable.Repeat`. For example:
csharp
static IAsyncEnumerable<bool> GetBoolsAsync() =>
    new[] { true }.ToAsyncEnumerable();
