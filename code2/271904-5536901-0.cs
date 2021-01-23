    protected void Page_Load(object sender, EventArgs e)
    {
        using (var proxy = new WebServiceClientProxy())
        {
            SomeModel[] data = proxy.GetData();
            gridView1.DataSource = data;
            gridView1.DataBind();
        }
    }
