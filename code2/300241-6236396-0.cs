    protected void Page_Load(object sender, EventArgs e)
    {
        d = new GridView();
        d.DataKeyNames = new string[] { "Column1", "Column2" };
        form1.Controls.Add(d);
    }
