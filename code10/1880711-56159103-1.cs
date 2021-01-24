    protected void RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && gvOrders.EditIndex == e.Row.RowIndex)
        {
            RadioButtonList rblShippers = (RadioButtonList)e.Row.FindControl("rblShippers");
            string query = "SELECT * FROM Shippers";
            SqlCommand cmd = new SqlCommand(query);
            rblShippers.DataSource = GetData(cmd);
            rblShippers.DataTextField = "CompanyName";
            rblShippers.DataValueField = "ShipperId";
            rblShippers.DataBind();
            rblShippers.Items.FindByValue((e.Row.FindControl("lblShipper") as Label).Text).Selected = true;
        }
    }
