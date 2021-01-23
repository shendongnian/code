    //This is the method to bind the gridview to the data.
    private void LoadGridview()
    {
        List<MyObject> MyObjectList = MyObject.FillMyList();
        if (MyObjectList != null && MyObjectList.Count > 0)
        {
            this.GridView1.DataSource = MyObjectList;
        	this.GridView1.DataBind();
        }
    }
    //When the index changes
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //Changes the page
        this.GridView1.PageIndex = e.NewPageIndex;
        LoadGridview();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //When the page loads
        LoadGridview();
    }
