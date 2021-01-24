    var contextDb = new YourContextDb();
    var newLibrary = new Library()
    {                
      Name = "My new library",
     };
     newLibrary = contextDb.Libraries.Add(newLibrary).Entity;
     var newBookshelf = new Bookshelf() { Color = "Blue" };
     newBookshelf = contextDb.Bookshelves.Add(newBookshelf).Entity;
     var newBook = new Book()
     {
        Title = "My New Book",
        LibraryId = newLibrary.Id,
        Bookshelf = newBookshelf
     };
     contextDb.Books.Add(newBook);
     contextDb.SaveChanges();
