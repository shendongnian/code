    static void Main(string[] args)
    {
        // Dispose will be called
        foreach(var value in GetEnumerable())
        {
            Console.WriteLine(value);
            break;
        }
        // Dispose will not be called
        var enumerable = GetEnumerable().GetEnumerator();
        while(enumerable.MoveNext())
        {
            Console.WriteLine(enumerable.Current);
            break;
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
