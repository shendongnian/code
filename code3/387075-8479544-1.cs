    List<Book> books = new List<Book>();
    books.Add(new Book() { Title = "Pure JavaScript", Price = 59.0M});
    XDocument xdoc = new XDocument(new XElement("books", books.Select( x=> new XElement("book", 
                                   new XAttribute("Title", x.Title), 
                                   new XAttribute("Price", x.Price)))));
