    private List<int> ProductIDs
    {
        get
        {
            if (this.ViewState["ProductIDs"] == null)
            {
                this.ViewState["ProductIDs"] = new List<int>();
            }
            return this.ViewState["ProductIDs"] as List<int>;
        }
    }
     
    protected void gvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        foreach (GridViewRow gvr in gvProducts.Rows)
        {
            CheckBox chkSelect = gvr.FindControl("chkSelect") as CheckBox;
            if (chkSelect != null)
            {
                int productID = Convert.ToInt32(gvProducts.DataKeys[gvr.RowIndex]["ProductID"]);
                if (chkSelect.Checked && !this.ProductIDs.Contains(productID))
                {
                    this.ProductIDs.Add(productID);
                }
                else if (!chkSelect.Checked && this.ProductIDs.Contains(productID))
                {
                    this.ProductIDs.Remove(productID);
                }
            }
        }
    }
     
    protected void gvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvr = e.Row;
        if (gvr.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkSelect = gvr.FindControl("chkSelect") as CheckBox;
            if (chkSelect != null)
            {
                int productID = Convert.ToInt32(gvProducts.DataKeys[gvr.RowIndex]["ProductID"]);
                chkSelect.Checked = this.ProductIDs.Contains(productID);
            }
        }
    }
