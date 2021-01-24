    var author = new Author {
        Name = "Arthur Conan Doyle",
        Born = new DateTime(1859, 5, 22),
        Died = new DateTime(1930, 7, 7)
    };
    var books = new List<Book>();
    var book = new Book {
         Title = "The Final Problem",
         Price = 10.50m
    };
    book.Authors.Add(author);
    books.Add(book);
    var book = new Book {
         Title = "The Adventure of the Empty House",
         Price = 11.20m
    };
    book.Authors.Add(author); // Adds the same author as in the previous book.
    books.Add(book);
