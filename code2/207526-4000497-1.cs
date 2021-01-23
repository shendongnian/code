    protected void uxGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ClearBackColor();
        
        GridViewRow row = uxGrid.Rows[e.NewEditIndex];
        row.BackColor = Color.LightYellow;
    } 
    private void ClearBackColor()
    {
        foreach (GridViewRow row in uxGrid.Rows)
        {
            row.BackColor = System.Drawing.Color.Transparent;
        }
    }
