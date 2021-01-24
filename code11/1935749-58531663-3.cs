    static void Main(string[] args)
    {
        // Dispose will be called
        foreach(var value in GetEnumerable())
        {
            Console.WriteLine(value);
            break;
        }
        try
        {
            // Dispose will be called even here
            foreach (var value in GetEnumerable())
            {
                Console.WriteLine(value);
                throw new Exception();
            }
        }
        catch // Lame
        {
        }
        // Dispose will not be called
        var enumerable = GetEnumerable().GetEnumerator();
        while(enumerable.MoveNext())
        {
            Console.WriteLine(enumerable.Current);
            break;
        }
        Console.WriteLine("{0}Here we'll see dispose on completion of manual enumeration.{0}", Environment.NewLine);
        // Dispose will be called: ended enumeration
        var enumerable2 = GetEnumerable().GetEnumerator();
        while (enumerable2.MoveNext())
        {
            Console.WriteLine(enumerable2.Current);                
        }
    }
    static IEnumerable<string> GetEnumerable()
    {
        using (new MyDisposer())
        {
            yield return "First";
            yield return "Second";
        }
        Console.WriteLine("Done with execution");
    }
    public class MyDisposer : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }
    }
