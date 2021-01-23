       protected void GridView_RowDataBound(..)
       {
           if (e.Row.RowType.Equals(DataControlRowType.DataRow))
            {
                DropDownList ddl = e.Row.FindControl("ddlMyQuantity") as DropDownList;
                if (ddl != null)
                {
                   for (int i = 1; i < 15; i++)
                   {
                       ddl.Items.Add(i.ToString());
                   }
                }
            }
       }
