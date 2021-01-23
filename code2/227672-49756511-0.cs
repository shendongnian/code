       var results = context.Categories.Where(...)
          .GroupJoin(
             context.Books.Where(...),
             cat => cat.Id,
             book => book.CategoryId, 
             (cat, books) => new 
             {
                 Category = cat,
                 Books = books.ToList()
                 Dummy_Authors = books.Select(b => b.Author).ToList() // dummy property
             });
