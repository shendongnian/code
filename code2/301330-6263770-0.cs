    private void ExportToExcel(string strFileName, GridView dg)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.Charset = "";
        System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(Response.Stream);
        oHtmlTextWriter.WriteLine("<b><u><font size='5'><font color='blue'><center> REPORT </center></font></u></b>");
        GridView1.RenderControl(oHtmlTextWriter);
        Response.End();
    } 
