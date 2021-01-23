    StringWriter sw = new StringWriter();
    HtmlTextWriter htw = new HtmlTextWriter(sw);
    // instantiate a datagrid
    DataGrid dg = new DataGrid();
    dg.DataSource = dataTable;
    dg.DataBind();
    dg.RenderControl(htw);
    response.Write(sw.ToString()); //HttpResponse object. 
