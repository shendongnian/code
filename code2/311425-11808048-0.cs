        try
        {
            if (e.CommandName == "Delete")
            {
                GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RemoveAt = gvr.RowIndex;
                DataTable dt = new DataTable();
                dt = (DataTable)ViewState["Products"];
                dt.Rows.RemoveAt(RemoveAt);
                dt.AcceptChanges();
                ViewState["Products"] = dt;
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    protected void gvProductsList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            gvProductsList.DataSource = ViewState["Products"];
            gvProductsList.DataBind();
        }
        catch (Exception ex)
        {
 
        }
    }
