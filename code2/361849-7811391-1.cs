    using (var db = new Db()) {
        var author = db.Authors.Include("Books.Editions").AsEnumerable().First();
        foreach (var book in author.Books)
        {
            foreach (var edition in book.Editions)
            {
                Response.Write(edition.Id + " - " + edition.Title + "<br />");
            }
        }
    }
