    protected void Gridview1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType.Equals(DataControlRowType.DataRow))
        {
            DropDownList Myddl = e.Row.FindControl("MyQuantity") as DropDownList;
            if (Myddl != null)
            {
                for (int i = 1; i < 15; i++)
                {
                    Myddl.Items.Add(i.ToString());
                }
            }
        }
       //here goes the "magic"
       DataRow dRow = e.Row.DataItem as DataRow;
       if(dRow != null)
       {
           Myddl.SelectedValue = dRow["Quantity"].ToString();
       }
    }
