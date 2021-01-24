    using (MyLibraryEntities db = new MyLibraryEntities())
                {
                    var query = db.Book.SelectMany(book =>
                            new {
                                bookID = book.BookID,
                                name = book.Name,
                                pageCount = book.PageCount,
                                authors = book.Authors.Select(i=>i.Name).ToList()
                            }).ToList<dynamic>();
                }
