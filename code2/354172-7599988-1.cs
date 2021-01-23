    protected void imgToggleGrid_Click(object sender, EventArgs e)
    {
        plcGrid.Visible = !plcGrid.Visible;        
        imgToggleGrid.ImageUrl = String.Format("~/images/{0}", plcGrid.Visible ? "hide.png" : "show.png");
    }
