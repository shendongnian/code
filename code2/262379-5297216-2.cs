    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["someSessionVal"].ToString() == "some value")
        {
            MyId.Visible = true;
        }
        else
        {
            MyId.Visible = false;
        }
    }
