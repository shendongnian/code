    protected void Page_Load(object sender, EventArgs e)
    {
        Control details = LoadControl("WebUserControl.ascx");
        PlaceHolder1.Controls.Add(details);
        Control details1 = LoadControl("WebUserControl2.ascx");
        PlaceHolder2.Controls.Add(details1);
    }
