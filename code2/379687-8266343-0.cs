    protected int widestData;
    protected void GridView1_RowDataBound(object sender, 
        GridViewRowEventArgs e)
    {
        System.Data.DataRowView drv;
        drv = (System.Data.DataRowView)e.Row.DataItem;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
          if (drv != null)
          {
            String catName = drv[1].ToString();
            Response.Write(catName + "/");
            
            int catNameLen = catName.Length;
            if (catNameLen > widestData)
            {
              widestData = catNameLen;
              GridView1.Columns[2].ItemStyle.Width =
                widestData * 30;
              GridView1.Columns[2].ItemStyle.Wrap = false;
            }
            
          }
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        widestData = 0;
    }
