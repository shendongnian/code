    static IEnumerable<string> GetLines(string filename)
    {
        using (var r = new StreamReader(filename))
        {
            string line;
            while ((line = r.ReadLine()) != null)
                yield return line;
        }
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine(GetLines("file.txt").Count());
        //Or, similarly: 
        int count = 0;
        foreach (var l in GetLines("file.txt"))
            count++;
        Console.WriteLine(count);
    }
