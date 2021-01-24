    public static void Main(string[] args)
    {
        var books = new List<Book>
        {
            new Book {Title = "Ulysses", PublishDate = new DateTime(2018, 12, 1)},
            new Book {Title = "Don Quixote", PublishDate = new DateTime(2018, 12, 1)},
            new Book {Title = "The Great Gatsby", PublishDate = new DateTime(2018, 12, 1)},
            new Book {Title = "Moby Dick", PublishDate = new DateTime(2018, 12, 1)},
            new Book {Title = "War and Peace", PublishDate = new DateTime(2018, 12, 1)},
            new Book {Title = "Hamlet", PublishDate = new DateTime(2018, 12, 1)},
            new Book {Title = "To Kill a Mockingbird", PublishDate = new DateTime(2018, 12, 1)},
            new Book {Title = "The Catcher in the Rye", PublishDate = new DateTime(2018, 12, 1)},
            new Book {Title = "The Hobbit", PublishDate = new DateTime(2018, 12, 1)},
            //new Book {Title = "Fahrenheit 451", PublishDate = new DateTime(2018, 12, 1)},
            //new Book {Title = "The Handmaid's Tale", PublishDate = new DateTime(2018, 12, 1)},
        };
        // Select the longest book title and add '8' for the date
        var columnWidth = books.Select(b => b.Title.Length).Max() + 8;
        var columnCount = 2;
        // Create our header for each column
        var header = "Book".PadRight(columnWidth - 5) + "Date";
        OutputInColumns(books.Select(b => AsColumnString(b, columnWidth)), columnCount, 
            columnWidth, header);
    }
