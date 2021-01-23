    void gridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
       if(e.Row.RowType == DataControlRowType.DataRow)
       {
           int type = int.Parse(e.Row.Cells[typeCellIndex].Text);
           Image img = (Image) e.Row.Cells[imageCellIndex].FindControl(imageID);
           switch type
           {
              case 1:
              {
                 img.ImageUrl = "avtivity_choise.jpg";
              }
              ......
           }
       }
     }
