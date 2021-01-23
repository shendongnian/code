    if (DropDownList1.SelectedItem.Text != "All")
        {
            SqlDataSource1.FilterExpression = "Title like '" + textbox1.Text + "' and Category like " + DropDownList1.SelectedValue;
        }
        else
        {
            SqlDataSource1.FilterExpression = "Title like '" + textbox1.Text + "'";
        }
     GridView1.DataBind();
           
