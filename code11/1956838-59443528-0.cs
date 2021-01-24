csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
class Program
{
    static async Task Main()
    {
        IAsyncEnumerable<string> empty = AsyncEnumerable.Empty<string>();
        var count = await empty.CountAsync();
        Console.WriteLine(count); // Prints 0
    }
}
