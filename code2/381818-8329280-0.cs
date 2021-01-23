    if (!Page.IsPostBack)
    {
        DataTable dt = new DataTable("MyDataTable");
        dt.Columns.Add("Value1");
        dt.Columns.Add("Value2");
        dt.Columns.Add("Value3");
        dt.Rows.Add(TextBox1.Text, TextBox2.Text, TextBox3.Text);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
