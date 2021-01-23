            var myFavoriteBooks = new System.Collections.Generic.Dictionary<string, book>();
            var allBooks = new System.Collections.Generic.Dictionary<string, book>();
            foreach (var bookName in myFavoriteBooks.Keys)
            {
                if (allBooks.ContainsKey(bookName))
                {
                    allBooks[bookName].IsFavorite = true;
                }
            }
