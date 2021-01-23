    public void bindComboBox(object sender, GridViewRowEventArgs e)
            {
    
                if (e.Row.RowType != DataControlRowType.DataRow)
                {
                    return;
                }
    
                DropDownList ddlist = (DropDownList)e.Row.FindControl("comboBox1");
                ddlist.AppendDataBoundItems = true;
                ddlist.DataSource = Test;  //insert your list here
                ddlist.DataBind();
    
            }
