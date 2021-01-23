    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> data = new List<string>();
        data.Add("Item 1");
        data.Add("Item 2");
        data.Add("Item 3");
        listView1.DataSource = data;
        listView1.DataBind();
    }
    protected void LinkButton_Click(object sender, EventArgs e)
    {
        //...
    }
