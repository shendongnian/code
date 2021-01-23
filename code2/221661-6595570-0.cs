    string items = "";
    string sql = "SELECT [BookID], [book_title] FROM [tblBook] WHERE [BookID] in (";
    foreach (BasketClass BookID in (List<BasketClass>)Session["CartSess"])
    {
        items += BookID & ",";
    }
    //Remove the trailing ","
    items.Remove(str.Length - 1, 1);
    GridView1.DataSource = cart;
    GridView1.DataBind();
    AccessDataSource1.SelectCommand = sql & items & ")";
