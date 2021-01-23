    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lbl = new Label(); 
        lbl.Text = grd.DataKeys[e.RowIndex]["LabelText"].ToString();
        lbl.ToolTip = grd.DataKeys[e.RowIndex]["TooltipText"].ToString();
    
        e.Row.Cells[0].Controls.Add(lbl);
    }
