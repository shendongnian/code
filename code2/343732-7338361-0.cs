    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lvTest.DataSource = new List<TestObj>{ obj1, obj2 ..};
            lvTest.DataBind();
        }
    
        lvTest.Items.RemoveAt(0);
    }
