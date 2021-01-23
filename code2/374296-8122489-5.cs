    protected void MyGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image img = (Image)e.Row.FindControl("Status");
          
            string messsageStatus = DataBinder.Eval(e.Row.DataItem, "MessageStatus") as string;
            
            if (messsageStatus == "Message Not Received")
            {
                img.ImageUrl = "Styles/Images/red.png";
                img.ToolTip = messsageStatus ;
            }
            else if (messsageStatus == "Message Received")
            {
                img.ImageUrl = "Styles/Images/amber.png";
                img.ToolTip = messsageStatus ;
            }
            img.Visible = true;
        }
    }
           
