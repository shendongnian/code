    protected override OnInit(EventArgs e)
    {
        base.OnInit(e);
    
        customers.RowDataBound += new GridViewRowEventHandler(customers_RowDataBound);
    }
    
    void customers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Customer currentCustomer = (Customer) e.Row.DataItem;
            Listbox books = (ListBox) e.Row.FindControl("books");
            books.DataSource = GetBooksCollection();
            books.DataBind();
    
            foreach (BooksPurchased currentBook in currentCustomer.booksCollection)
            {
                if (books.Contains(currentBook))
                {
                    books.Selected = true;
                }
            }
        }
    }
