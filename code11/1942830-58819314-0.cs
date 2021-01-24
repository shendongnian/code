    var doc = XDocument.Load(xmlFilePath); 
    var books = doc.Descendants().Where(x => x.Name == "book");
    string requestedBookId = Console.ReadLine();
    var requestedBook = books.FirstOrDefault(x => x.Attribute("id").Value == requestedBookId);
    if (requestedBook == null)
    {
        Console.WriteLine($"book with id '{requestedBookId}' not found");
    }
    else
    {
        var price = requestedBook.Descendants().First(x => x.Name == "price");
        price.Value = Console.ReadLine();
        doc.Save(xmlFilePath);
        Console.WriteLine("price updated!");
    }
