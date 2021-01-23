    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    DataRowView row = e.Item.DataItem as DataRowView;
     
                    DropDownList dl = e.Item.FindControl("ddlCategory") as DropDownList;
                    dl.DataSource = CategoriesDataTable;
                    dl.DataTextField = "CategoryDescription";
                    dl.DataValueField = "CategoryPK";
                    dl.SelectedValue = row["CategoryFK"].ToString();
                    dl.DataBind();
                }
