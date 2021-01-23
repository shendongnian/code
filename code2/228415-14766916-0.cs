            // Find a book by its ID.
            Book result = Books.Find(
            delegate(Book bk)
            {
                return bk.ID == IDtoFind;
            }
            );
            if (result != null)
            {
                DisplayResult(result, "Find by ID: " + IDtoFind);   
            }
            else
            {
                Console.WriteLine("\nNot found: {0}", IDtoFind);
            }
