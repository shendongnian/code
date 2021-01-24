      please try this code
       protected void Grid_SelectedIndexChanged(object sender, EventArgs e)
        {
           GridViewRow row = gvSummary.SelectedRow;
           string name= row.Attributes["Name"].ToString());
           string brandName = row.Attributes["brand_name"].ToString());
            DropDownList1.SelectedValue = name
            DropDownList2.SelectedValue = brandName; 
    
         } 
