    // In SamplePage.aspx.cs
    protected void Page_Load(object sender, EventArgs e)
    {
        var getRegions = new Dictionary<string, string>();
        getRegions.Add("Region1", "England");
        getRegions.Add("Region2", "Scotland");
        getRegions.Add("Region3", "Wales");
        Store1.DataSource = getRegions;
        Store1.DataBind();
    }
