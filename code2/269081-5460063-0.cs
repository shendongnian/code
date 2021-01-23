    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if(e.Row.RowType == DataControlRowType.DataRow)
      {
        
        System.Data.DataRowView dr = (System.Data.DataRowView)e.Row.DataItem;
        if (Convert.ToBoolean(dr["columnName"].ToString()))
        {
             LinkButton LinkButton = (LinkButton)e.Row.Findcontrol("LinkButton");
             LinkButton.Visible = false;
        }
       
      }
    }
