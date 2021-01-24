    int resultNo = 1;
    foreach (ResultDoubleList item in result) {
        Console.WriteLine($"\r\nresult({resultNo++}):");
        Console.WriteLine("Books");
        foreach (var book in item.Books) {
            Console.WriteLine($"    {book.Title,-28} {book.Pages,3}");
        }
        Console.WriteLine("Readers");
        foreach (var reader in item.Readers) {
            Console.WriteLine($"    {reader.Name,-8} {reader.Age,2}");
        }
    }
    Console.ReadKey();
