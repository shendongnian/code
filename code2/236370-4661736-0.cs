    Response.ContentType = "application/vnd.ms-excel";
    Response.AddHeader("Content-Disposition", "attachment;filename=myfilename.xls");
    var grid = new DataGrid();
    grid.DataSource = myList;
    grid.DataBind();
    grid.Render(writer);
    Response.End();
