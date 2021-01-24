    var book = new Book() { id = "1"};
    using (var stringwriter = new System.IO.StringWriter())
    {
        var serializer = new XmlSerializer(book.GetType());
        serializer.Serialize(stringwriter, book);
        Console.WriteLine(stringwriter.ToString());
    }
