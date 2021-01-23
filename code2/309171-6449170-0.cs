    if (string.IsNullOrEmpty(txtSearchProductname.Text) == true)
    {
        if (DropDownList1.SelectedValue == null)
        {
            txtSearchProductname.Text = " ";
        }
        else 
        {
            SqlProductmaster.InsertParameters["ProductName"].DefaultValue = DropDownList1.SelectedValue;
        }                
        }
    else 
    {
        SqlProductmaster.InsertParameters["ProductName"].DefaultValue = txtProductName.Text;
    }        
