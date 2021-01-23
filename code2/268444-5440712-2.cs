            foreach (Book book in b)
            {
                List<string> bookDetails = new List<string>(); //<-- move this line
                bookDetails.Add(book.BookTitle);
                bookDetails.Add(book.BookAuthor);
                bookDetails.Add(lib.LibraryName);
                bookDetails.Add(book.BookGenre);
                listOfBooks.Add(bookDetails);
            }
