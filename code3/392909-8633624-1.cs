    protected void gridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton myImageButton = e.Row.FindControl("myImageButton") as ImageButton;
            if (myImageButton != null)
            {
                if (Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "myBooleanField")))
                {
                    myImageButton.ImageUrl = "image1.jpg";
                }
                else
                {
                    myImageButton.ImageUrl = "image2.jpg";
                }
            }
        }
    }
