    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            switch (ddl1.SelectedValue)
            {
                case "1":
                    var ctl = LoadControl("Controls/UserControl.ascx");
                    ph1.Controls.Add(ctl);
                    break;
                case "2":
                    ctl = LoadControl("Controls/UserControl2.ascx");
                    ph1.Controls.Add(ctl);
                    break;
            } 
        }
    }
