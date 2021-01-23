    protected void yourNiceGridViewControl_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.Footer)
      {
        TextBox myTextBox = e.Row.FindControl("txtFooter") as TextBox;
    
        if( myTextBox != null ) 
        {
    
          myTextBox.Tex= ds.Tables[0].Rows[0]["MyFirend"].ToString();
        }
      }
    }
