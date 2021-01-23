    protected void imgToggleGrid_Click(object sender, EventArgs e)
    {
        rgRegistrationHistory.Visible = !rgRegistrationHistory.Visible;        
        imgToggleGrid.ImageUrl = String.Format("~/images/{0}", rgRegistrationHistory.Visible ? "hide.png" : "show.png");
    }
