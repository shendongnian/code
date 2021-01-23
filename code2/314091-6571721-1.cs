    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmployeeType"].ToString() == "1")
        {
            AdminMenu.Visible = true;
            UserMenu.Visible = false;
        }
        else
        {
            AdminMenu.Visible = false;
            UserMenu.Visible = true;
        }
    }
