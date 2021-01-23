    public void ddlProducts_SelectedIndexChanged(object sender, EventArgs e) 
        { 
            if ("Banana".Equals(ddlProducts.SelectedItem.ToString(),  StringComparison.OrdinalIgnoreCase) 
            { 
                productQuantity.Text = ddlProducts.SelectedValue.ToString(); 
                productQuantity.Visible = true; 
            } 
        }
 
