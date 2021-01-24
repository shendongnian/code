    Book selectedBook = lstBooks.SelectedItem as Book;
    if (selectedBook != null)
    {
        txtIsbn.Text = selectedBook.Isbn;
        txtName.Text = selectedBook.Name;
    }
    else
        MessageBox.Show("Please select a book");
