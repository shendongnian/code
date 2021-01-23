     protected void GridViewProducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if(e.Row.RowType = DataControlRowType.DataRow){
        if(!File.Exist(yourFileName){
            //hide the image
            var img=e.Row.FindControl("theImageId");
            img.visible=false;
         }
       }
    }
