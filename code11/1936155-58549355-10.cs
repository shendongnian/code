    public static void Main(string[] args)
    {
        var books = new List<Book>
        {
            new Book {Title = "Ulysses", PublishDate = DateTime.Parse("February 2, 1922")},
            new Book {Title = "Don Quixote", PublishDate = DateTime.Parse("January 16, 1605")},
            new Book {Title = "The Great Gatsby", PublishDate = DateTime.Parse("April 10, 1925")},
            new Book {Title = "Moby Dick", PublishDate = DateTime.Parse("October 18, 1851")},
            new Book {Title = "War and Peace", PublishDate = DateTime.Parse("January 1, 1869")},
            new Book {Title = "Hamlet", PublishDate = DateTime.Parse("January 1, 1603")},
            new Book {Title = "To Kill a Mockingbird", PublishDate = DateTime.Parse("July 11, 1960")},
            new Book {Title = "The Catcher in the Rye", PublishDate = DateTime.Parse("July 16, 1951")},
            new Book {Title = "The Hobbit", PublishDate = DateTime.Parse("September 21, 1937")},
            new Book {Title = "Fahrenheit 451", PublishDate = DateTime.Parse("October 19, 1953")},
            new Book {Title = "The Handmaid's Tale", PublishDate = DateTime.Parse("January 1, 1985")},
        };
        // Select the longest book title and add '8' for the three dots and the date
        var columnWidth = books.Select(b => b.Title.Length).Max() + 8;
        var columnCount = 2;
        // Create our header for each column
        var header = "Book".PadRight(columnWidth - 5) + "Date";
        OutputInColumns(books.Select(b => AsColumnString(b, columnWidth)).ToList(), 
            columnCount, columnWidth, header);
    }
