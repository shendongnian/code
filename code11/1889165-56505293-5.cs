    var contextDb = new LabContextDb();
    var newLibrary = new Library()
    {                
       Id = 1,
       Name = "My new library",
    };
    newLibrary = contextDb.Libraries.Add(newLibrary).Entity;
     var newBookshelf = new Bookshelf() { Id = 2, Color = "Blue" };
     newBookshelf = contextDb.Bookshelves.Add(newBookshelf).Entity;
     var newBook = new Book()
     {
        Id = 5,
        Title = "My New Book",
        LibraryId = newLibrary.Id,
        Bookshelf = newBookshelf
      };
     contextDb.Books.Add(newBook);
     contextDb.SaveChanges();
