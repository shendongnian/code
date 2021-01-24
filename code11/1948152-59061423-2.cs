    // check footer row is not null
    if(GridView1.FooterRow != null)
    {
        // save control you want to edit to a variable
        var lblQty = ((Label)GridView1.FooterRow.FindControl("lblQuantity"));
        if(lblQty != null) 
        {
            // only update the text if it's not null
            lblQty.Text = totalQauntity.ToString();
        }
        var lblAmt = ((Label)GridView1.FooterRow.FindControl("lblAmount"));
        if(lblAmt != null) 
        {
            lblAmt.Text = totalAmount.ToString();
        }
    }
    if(dt.Rows.Count > 0)
    {
        Response.Redirect("~/ClientPages/ViewCart.aspx");
    }
    else
    {
        Response.Redirect("~/ClientPages/Error Message.aspx");
    }
