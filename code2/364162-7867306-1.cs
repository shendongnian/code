    book = db.Books.Single(b => b.BookId == book.BookId);
     var bookCopies = db.BookCopies.Where(c => c.BookId == book.BookId).ToList();
    
     foreach (BookCopy c in bookCopies)
     {
         db.BookCopies.DeleteObject(c);
     }
    
     var authors = db.Authors.Include("Books").Where(author => author.Books.Any(b => b.BookId == book.BookId)).ToList();
    
     foreach (Author a in authors)
     {
         a.Books.Remove(book);
     }
     
     db.DeleteObject(book);
     db.SaveChanges();
