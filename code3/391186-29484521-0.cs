    public void ExportReport(XtraReport report, string fileName, string fileType, bool inline)
    {
        MemoryStream stream = new MemoryStream();
        Response.Clear();
        if (fileType == "xls")
            report.ExportToXls(stream);
        if (fileType == "pdf")
            report.ExportToPdf(stream);
        if (fileType == "rtf")
            report.ExportToRtf(stream);
        if (fileType == "csv")
            report.ExportToCsv(stream);
        Response.ContentType = "application/" + fileType;
        Response.AddHeader("Accept-Header", stream.Length.ToString());
        Response.AddHeader("Content-Disposition", String.Format("{0}; filename={1}.{2}", (inline ? "Inline" : "Attachment"), fileName, fileType));
        Response.AddHeader("Content-Length", stream.Length.ToString());
        //Response.ContentEncoding = System.Text.Encoding.Default;
        Response.BinaryWrite(stream.ToArray());
    
        Response.End();
    }
