    [HttpPut]
        public List<ChangeLog> UpdateBook(Books input)
        {
            var bookToChange = _context.Books.Find(input.BookId);
            bookToChange.BookName = input.BookName;
            bookToChange.BookPrice = input.BookPrice;
            bookToChange.Author = input.Author;
            _context.Books.Update(bookToChange);
            var changeLog = GetChangeLog();
            return changeLog;
        }
        public List<ChangeLog> GetChangeLog()
        {
            List<ChangeLog> changeLog = new List<ChangeLog>();
            var changedEntities = _context.ChangeTracker.Entries().Where(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Modified).ToList();
            changedEntities.ForEach(change => {
                foreach (var prop in change.OriginalValues.Properties)
                {
                    var originalValue = change.OriginalValues[prop].ToString();
                    var updatedValue = change.CurrentValues[prop].ToString();
                    if (originalValue != updatedValue)
                    {
                        var changes = new ChangeLog
                        {
                            Property = prop.Name,
                            oldValue = originalValue,
                            newValue = updatedValue,
                            dateOfChange = DateTime.Now
                        };
                        changeLog.Add(changes);
                    }
                }
            });
             
            return changeLog;
        }
