    var groups = new List<List<Book>>();
    foreach (var book in books)
    {
        bool found = false;
        foreach (var g in groups)
        {
            if (sameGroup(book.Title, g[0].Title))
            {
                found = true;
                g.Add(book);
                break;
            }
        }
        if (!found)
            groups.Add(new List<Book> { book });
    }
    var result = groups.Select(g => g.OrderBy(b => b.Date).ToArray()).ToArray();
