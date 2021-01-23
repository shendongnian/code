    protected void Page_Load(object sender, EventArgs e)
    {
        var items = new[] { new { Id = 1, Name = "Test1" }, new { Id = 2, Name = "Test2" } };
        dropDownList.DataSource = items;
        dropDownList.DataValueField = "Id";
        dropDownList.DataTextField = "Name";
        dropDownList.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        dropDownList.SelectedValue = ""; // trhows exception
        dropDownList.ClearSelection(); // works
    }
