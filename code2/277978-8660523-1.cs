    protected void Page_Load(object sender, EventArgs e)
    {
        hdnDBTags.Value = "real_estate,mortgage_lending";
    }
    protected void btnGetTags_Click(object sender, EventArgs e)
    {
        string test = hdnSelectedTags.Value;
        IList<string> array = test.Split(',').ToList();
        array.Remove("");
    }
