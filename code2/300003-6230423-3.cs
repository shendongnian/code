     private void button1_Click(object sender, EventArgs e)
            {
                BookService bookService = new BookService();
                IList<BookViewModel> books = bookService.GetBookViewModel();
                if (books.Count == 0)
    	        {
                            Label1.Text = "Sorry no books were found";
    	        }
                dataGridView1.DataSource = books;
            }
