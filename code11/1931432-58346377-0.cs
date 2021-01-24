    static async Task Main(string[] args)
    {
        await foreach (var line in GetLines())
        {
            Console.WriteLine(line);
        }
    }
    private static async IAsyncEnumerable<string> GetLines()
    {
        var reader = new StringReader("Line1\nLine2\nLine3");
        try
        {
            while (true)
            {
                var line = await reader.ReadLineAsync();
                if (line == null) break;
                yield return line;
            }
        }
        finally
        {
            reader.Dispose();
            Console.WriteLine("Disposed");
        }
    }
