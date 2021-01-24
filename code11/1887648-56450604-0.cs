    public BookDto Execute(int request)
        {
            var book = _context.Books
                .Single(b => b.Id == request)
                .Select(s => new BookDto() {
                   Id = s.Id,
                   Title = s.Title,
                   Writer = s.Writer.Name,
                   Description = s.Description,
                   AvailableCount = s.AvailableCount,
                   BookGenres = s.BookGenres.ToList()
            });
        }
