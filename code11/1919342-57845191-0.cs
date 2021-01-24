    Person person = db.Person
                    .Where(p => p.PersonID == 1) // change this
                    .Include(ba => ba.BookAuthor.Select(a => a.Author)
                    .Include(bg => bg.BookGenre.Select(g => g.Genre)
                    .First();
