    var results = flatManyToMany
    .GroupBy(f => new { f.BookTitle, f.BookPages })
    .Select(g => new
    {
        Book = new Book() { Title = g.Key.BookTitle, Pages = g.Key.BookPages },
        Readers = g.Select(i => new Reader() { Name = i.ReaderName, Age = i.ReaderAge })
    })
    .GroupBy(i => string.Concat(i.Readers.Select(r => r.Name).Distinct()))
    .Select(g => new ResultDoubleList()
    {
        Books = g.Select(i => i.Book).ToList(),
        Readers = g.SelectMany(i => i.Readers).GroupBy(r => r.Name).Select(r => r.First()).ToList()
    })
    ;
C#
    foreach(var result in results)
    {
        Console.WriteLine("Result:");
        Console.WriteLine("\tBooks:");
        foreach(var b in result.Books)
        {
            Console.WriteLine($"\t\t{b.Title}");
        }
        Console.WriteLine("\tReaders:");
        foreach (var reader in result.Readers)
        {
            Console.WriteLine($"\t\t{reader.Name}");
        }
    }
