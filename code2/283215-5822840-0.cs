    using (var context = new BookContext())
    {
        book.Title = "This is the new title";
        context.SaveChanges();
        book.Comments.Add(new Comment("This is a comment"));
        context.SaveChanges();
    }
