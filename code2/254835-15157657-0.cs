    protected override void Render(HtmlTextWriter writer) {
    
        foreach (GridViewRow r in gridviewPools.Rows) {
            if (r.RowType == DataControlRowType.DataRow) {
                Page.ClientScript.RegisterForEventValidation(gridviewPools.UniqueID, "Select$" + r.RowIndex);
            }
        }
    
        base.Render(writer);
    }
