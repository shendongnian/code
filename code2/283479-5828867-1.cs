    public void CreatePDFDocument(string strHtml)
        {
    
            string strFileName = HttpContext.Current.Server.MapPath("test.pdf");
            // step 1: creation of a document-object
            Document document = new Document();
            // step 2:
            // we create a writer that listens to the document
            PdfWriter.GetInstance(document, new FileStream(strFileName, FileMode.Create));
            StringReader se = new StringReader(strHtml);
            HTMLWorker obj = new HTMLWorker(document);
            document.Open();
            obj.Parse(se);
            document.Close();
            ShowPdf(strFileName);
    
    
    
        }
  
    public void ShowPdf(string strFileName)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);
            Response.ContentType = "application/pdf";
            Response.WriteFile(strFileName);
            Response.Flush();
            Response.Clear();
        }
