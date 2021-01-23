    DataTable people = (DataTable)Session["people"];
     
    // Open excel file and insert data table.
    ExcelFile ef = new ExcelFile();
    ef.LoadXls(Server.MapPath("MyData.xls"));
    ExcelWorksheet ws = ef.Worksheets[0];
    ws.InsertDataTable(people, "A1", true);
     
    Response.Clear();
     
    // Stream file to browser, in required type.
    switch (this.RadioButtonList1.SelectedValue)
    {
        case "XLS":
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment; filename=" +
                 "Report.xls");
            ef.SaveXls(Response.OutputStream);
            break;
     
        case "XLSX":
            Response.ContentType = "application/vnd.openxmlformats";
            Response.AddHeader("Content-Disposition", "attachment; filename=" +
                 "Report.xlsx");
            // With XLSX it is a bit more complicated as MS Packaging API
            // can't write directly to Response.OutputStream.
            // Therefore we use temporary MemoryStream.
            MemoryStream ms = new MemoryStream();
            ef.SaveXlsx(ms)
            ms.WriteTo(Response.OutputStream);
            break;
    }
    Response.End();
