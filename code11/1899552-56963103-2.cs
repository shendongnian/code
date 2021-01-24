    private void ExportGridToPDF()  
    {  
  
        Response.ContentType = "application/pdf";  
        Response.AddHeader("content-disposition", "attachment;filename=FileName.pdf");  
        Response.Cache.SetCacheability(HttpCacheability.NoCache);  
        StringWriter sw = new StringWriter();  
        HtmlTextWriter hw = new HtmlTextWriter(sw);  
        GridView1.RenderControl(hw);  
        StringReader sr = new StringReader(sw.ToString());  
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);  
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);  
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);  
        pdfDoc.Open();  
        htmlparser.Parse(sr);  
        pdfDoc.Close();  
        Response.Write(pdfDoc);  
        Response.End();  
        GridView1.AllowPaging = true;  
        GridView1.DataBind();  
    }  
