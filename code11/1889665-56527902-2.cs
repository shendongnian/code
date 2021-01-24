    static void Main()
    {
        foreach (var col in getColors(1))
        {
            Console.WriteLine(col == null);
        }
        Console.ReadLine();
    }
    static IEnumerable<System.Drawing.Color?> getColors(long Id)
    {
        yield return null;
    }
