    var context = new MySqliteDatabase(new SQLiteConnection(@"DataSource=D:\\Mydb.db;cache=shared"));
    var author = new Author {
        FirstName = "William",
        LastName = "Shakespeare",
        Books = new List<Book>
        {
            new Book { Title = "Hamlet"},
            new Book { Title = "Othello" },
            new Book { Title = "MacBeth" }
        }
    };
    context.Add(author);
    context.SaveChanges();
