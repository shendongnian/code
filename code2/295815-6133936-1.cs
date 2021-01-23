    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow )
        {            
            var theItem = e.Row.DataItem as MyItemType;
            e.Row.Attributes.Add("onclick","update('" + e.Row.RowIndex + "')");
            e.Row.Style.Add("cursor", "pointer"); 
        }
    }
