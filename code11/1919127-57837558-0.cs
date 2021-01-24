    using (MyLibraryEntities db = new MyLibraryEntities())
                {
                    var query = db.Book.SelectMany(book =>
                            new {
                                bookID = book.BookID,
                                name = book.Name,
                                pageCount = book.PageCount,
                                //I assume your Book Entity has Collection of Author
                                authors = book.Authors.Select(i=>i.Name).ToList()
                            }).ToList<dynamic>();
                }
