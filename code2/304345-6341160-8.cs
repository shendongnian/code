    protected void Page_Load(object sender, EventArgs e)
    {
        List<ThatClass> cList = new List<ThatClass>();
        cList.Add(new ThatClass("123", "abc"));
        cList.Add(new ThatClass("456", "def"));
        gv.DataSource = cList;
        gv.DataBind();
    }
