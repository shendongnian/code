    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            var dataItem = e.Row.DataItem as MyRow;
            Button btnShowImage = e.Row.FindControl("btnShowImage") as Button;
            
            if(dataItem.screenshotId != null && screenshotId > 0)
            {
                btnShowImage.OnClientClick = 
                   "javascript:ShowImageInNewPage(\"DisplayImage.aspx?screenshotId=" +  dataItem.screenshotId + "\");";
                btnShowImage.Visible = true;
            }
            else
                btnShowImage.Visible = false;
        }
    }
