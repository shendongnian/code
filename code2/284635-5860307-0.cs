    MyRepeaterControl.ItemDataBound += new RepeaterItemEventHandler(MyRepeaterControl_ItemDataBound);
    
    void MyRepeaterControl_ItemDataBound(object sender, RepeaterItemEventArgs e)
    		{
    			if (e.Item.ItemIndex > -1)
    			{
    				ImageButton image = e.Item.FindControl("MY_IMAGE_CONTROL") as ImageButton;
    
    				image.ImageUrl = "IMAGE_PATH";
    			}
    		}
