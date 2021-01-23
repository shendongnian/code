    //now e is a 
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            // blah blah blah, this lets you work on one row at a time.
            // since the framework does this per row, you don't need to parse the gridview
            // yourself, altho you're more than welcome to.
            // But you can get more control this way. I promise.
            Label Label3 = (Label)e.Row.FindControl("Label3");
            int val = Convert.ToInt32(Label3.Text);
            Image Image5 = (Image)e.Row.FindControl("Image5");
            if (val < 0)
            {
                Image5.ImageUrl = "~/NewFolder1/warning_16x16.gif";
            }
            else
            {
                Image5.ImageUrl = "~/NewFolder1/1258341827_tick.png";
            }
            // alternately write the code above like this:
            Image Image5 = (Image)e.Row.FindControl("Image5");
            Image5.ImageUrl = (val < 0) ? "~/NewFolder1/warning_16x16.gif" : "~/NewFolder1/1258341827_tick.png";
            // that's called the ternary operator. Takes up less space, does the same thing.
        }
    }
