    protected void **GridView2_RowDataBound**(object sender, GridViewRowEventArgs e)
        {
           string cities = "maxico,chennai,newdelhi,hongkong";
           string [] arr = cities.Split(',');
        // Instead of string array it could be your data retrieved from database.
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = (DropDownList)e.Row.FindControl("DrdDatabase");
                foreach (string colName in arr )
                    ddl.Items.Add(new ListItem(colName));
            }
        }
