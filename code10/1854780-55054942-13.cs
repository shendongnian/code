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
    book.Authors.Add(author); // Adds the same author as in the previous book. Note that a class is
                              // a reference type. I.e., this is not a copy of the author. It is
                              // a reference to the same and unique A. C. Doyle `Author` object.
    books.Add(book);
    var book = new Book {
         Title = "Hilda Wade",
         Price = 8.75m
    };
    book.Authors.Add(author);
    book.Authors.Add(new Author {
        Name = "Grant Allen",
        Born = new DateTime(1848, 2, 24),
        Died = new DateTime(1899, 10, 25)
    }); // A co-author.
    books.Add(book);
