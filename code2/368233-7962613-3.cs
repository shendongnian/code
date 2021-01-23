    private void bindGridView()
    {
        DataTable t = new DataTable();
        t.Columns.Add("ImagePath");
        DataRow r = null;
        for (int i = 0; i < 5; i++)
        {
            r = t.NewRow();
            r.ItemArray = new object[] { "images/couple24.png"};
            t.Rows.Add(r);
        }
        GridView1.DataSource = t;
        GridView1.DataBind();
    }
