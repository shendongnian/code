    void grv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
          if(condition)
          {
           ImageButton imgBtn= (ImageButton)e.Row.FindControl("mybuttonid");
           imgBtn.Visible = false;
          }
      }
    }
