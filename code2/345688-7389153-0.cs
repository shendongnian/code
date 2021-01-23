    protected void MyGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image img = (Image)e.Row.FindControl("image1");
            //condition for red image; Neither TimeReceived and TimeRead are populated
            if(string.IsNullOrEmpty(e.Row.Cells[1].Text) &&  
               string.IsNullOrEmpty(e.Row.Cells[2].Text))
            {
                img.ImageUrl = "/images/Red.gif";
                img.Visible = true;
            }
            //condition for amber image; TimeReceived not null and TimeRead is null
            else if (!string.IsNullOrEmpty(e.Row.Cells[1].Text) &&  
                     string.IsNullOrEmpty(e.Row.Cells[2].Text))
            {
                img.ImageUrl = "/images/Amber.gif";
                img.Visible = true;
            }
            //condition for green image; TimeReceived not null and TimeRead not null
            else if (!string.IsNullOrEmpty(e.Row.Cells[1].Text) &&  
                     !string.IsNullOrEmpty(e.Row.Cells[2].Text))
            {
               img.ImageUrl = "/images/Green.gif";
               img.Visible = true;
            }
            else //default case
            {
                img.Visible = false;
            }
        }
    }
