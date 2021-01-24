    if (borrow.Button.Equals("Return"))
        {
            foreach (Book borrowBook in borrow.Library.BookList)
            {
                if (borrowBook.IsChecked)
                {
                    subscriberBookEntity.ReturnDate = DateTime.Now;
                    Manager.UpdateBorrow(subscriberBookEntity);
                }
            }
