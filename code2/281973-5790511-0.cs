     using (StringWriter sw = new StringWriter("Your Path to save"))
    {
      using (HtmlTextWriter htw = new HtmlTextWriter(sw))
      {
        // instantiate a datagrid
         DataGrid dg = new DataGrid();
         dg.DataSource = ds.Tables[0];
         dg.DataBind();
        dg.RenderControl(htw);
       }
     }
