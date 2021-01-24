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
    static IAsyncEnumerable<bool> GetBoolsAsync() =>
        GetBools().ToAsyncEnumerable();
    static IEnumerable<bool> GetBools()
    {
        yield return true;
        yield break;
    }
}
