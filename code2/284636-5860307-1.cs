    MyGrid.RowDataBound += new RepeaterItemEventHandler(MyGrid_RowDataBound);
    
    void MyGrid_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowIndex > -1)
			{
				ImageButton image = e.Row.FindControl("MY_IMAGE_CONTROL") as ImageButton;
				image.ImageUrl = "PATH_TO_IMAGE";
			}
		}
