    public void ExportGridToExcel(GridView grdGridView, string fileName)
    {
    Response.ClearContent();    
    Response.AddHeader("content-disposition",
        string.Format("attachment;filename={0}.xls", fileName));
    Response.ContentType = "application/vnd.xls";
    StringWriter stringWrite = new StringWriter();
    HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
    grdGridView.RenderControl(htmlWrite);
    Response.Write(stringWrite.ToString());
    Response.Flush();
    Response.End();
    }
