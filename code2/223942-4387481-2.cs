    public void ConvertHtmlStringToPDF()
    {
        StringBuilder sb = new StringBuilder(); 
        StringWriter tw = new StringWriter(sb); 
        HtmlTextWriter hw = new HtmlTextWriter(tw); 
        ///This is the panel from the webform
        pnlPDF.RenderControl(hw);
        string htmlDisplayText = sb.ToString(); 
        Document document = new Document();
        MemoryStream ms = new MemoryStream();
        PdfWriter writer = PdfWriter.GetInstance(document, ms);
        StringReader se = new StringReader(htmlDisplayText);
        HTMLWorker obj = new HTMLWorker(document);
        document.Open();
        obj.Parse(se);
        // step 5: we close the document
        document.Close();
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment; filename=report.pdf");
        Response.ContentType = "application/pdf";
        Response.Buffer = true;
        Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
        Response.OutputStream.Flush();
        Response.End();
    }
