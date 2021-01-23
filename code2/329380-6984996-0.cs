    Book book = ... 
    Publisher publisher = context.Publishers
                                 .Where(x => x.PublisherId == book.PublisherId)
                                 .SingleOrDefault();
    if(publisher != null)
        Console.WriteLine(publisher.Title);
