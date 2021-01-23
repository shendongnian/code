    // using System.Linq;
    
    var emailLines = ReadFileLines(@"C:\textFileName.txt")
        .Where(line => currentLine.StartsWith("Email: "))
        .Distinct()
        .ToList();
    
    public IEnumerable<string> ReadFileLines(string fileName)
    {
        using (var stream = new StreamReader(fileName))
        {
            while (!stream.EndOfStream)
            {
                yield return stream.ReadLine();
            }
        }
    }
