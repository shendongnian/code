    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
     if (DropDownList1.SelectedValue == "Abe Books")
    {
        DropDownSeller.Visible = true;
        lnkUsdBooks.Visible = true;
        lnkUsdBooks.Text = "usedbooks@abe.com";
        lnkUsdBooks.NavigateUrl = "mailto:usedbook@abe.com";
        DropDownSeller.Visible = true;
        DropDownSeller.Items.Remove("Chacha Choudary");
        DropDownSeller.Items.Remove("SpiderMan");
        DropDownSeller.Items.Remove("Amar chitra Katha");
        DropDownSeller.Items.Remove("Chandamama");
        DropDownSeller.Items.Remove("Mahabharata");
        DropDownSeller.Items.Add("Amar chitra Katha");
        DropDownSeller.Items.Add("Chandamama");
        DropDownSeller.Items.Add("Mahabharata");
        DropDownSeller.DataBind();
       
            if (DropDownSeller.SelectedValue == "Amar chitra Katha")
            {
                lblPrice.Visible = true;
                lblPrice.Text = "$69.99";
            }
            else if (DropDownSeller.SelectedValue == "Chandamama")
            {
                lblPrice.Visible = true;
                lblPrice.Text = "$59.99";
            }
            else if (DropDownSeller.SelectedValue == "Mahabharata")
            {
                lblPrice.Visible = true;
                lblPrice.Text = "$49.99";
            }
            else
            {
                lblPrice.Visible = false;
            }
        
    }
