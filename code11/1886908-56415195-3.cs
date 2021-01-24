    var books = db.GetCollection<Book>("books");
    var publishers = db.GetCollection<Publisher>("publishers");
    var q = from book in books.AsQueryable()
            join publisher in publishers.AsQueryable() on
                book.publisher_id equals publisher._id
            select new
            {
                book,
                publisher = publisher
            };
    var result = q.ToList();
