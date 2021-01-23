     protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Rating")
        {
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            Int32 Id = Convert.ToInt32(e.CommandArgument);
            ratingScore = ((AjaxControlToolkit.Rating)row.FindControl("Rating2")).CurrentRating;
        }
    }
