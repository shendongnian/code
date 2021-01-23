    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    
        Session["SavedSelection"] = DropDownList1.SelectedIndex ;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["SavedSelection"] != null)
        {
            int  selectedIndex = (int) Session["SavedSelection"];
            DropDownList1.SelectedIndex = selectedIndex;
        }
    }
