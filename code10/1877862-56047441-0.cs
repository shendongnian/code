    List<Book> names = Book.GetBooks("books.txt");
        
    Console.WriteLine("Books that are published by O'Reilly:");
        
    var a = names.Where(x => x.Publisher.Contains("O'Reilly"));
    a.ToList().ForEach(x => Console.WriteLine("---> '" + x.Name + "'"));
