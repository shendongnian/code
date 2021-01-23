        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var dropdown = e.Row.FindControl("someId") as DropDownList;
                //dropdown.DataSource= <>; bind it
                //dropdown.SelectedValue =<>"; / set value how you would 
            }
        }
