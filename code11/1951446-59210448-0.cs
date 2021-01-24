    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Book(int? id, List<int> SelectedCategoryValues, Book book)
        {
            var bookCategories = new List<BookCategory>();
            foreach (var c in _context.Categories)
            {
                bookCategories.Add(
                    new BookCategory() { BookId = book.BookId, CategoryId = c.CategoryId, IsSelected = SelectedCategoryValues.Contains(c.CategoryId) ? true : false }
                );
            }
            book.BookCategories = bookCategories;
            //...
        }
