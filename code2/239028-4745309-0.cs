    public void ProcessRequest (HttpContext context) 
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Context = context;
        Response = context.Response;
        Request = context.Request;
        Response.BufferOutput = true;
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment; filename=itextsharp_multiple.pdf");
        var pageBytes = (byte[])null;
        var pagesAll = new List<byte[]>();        
        
        try 
		{
            for (int i = 0; i < GlobalHttpApplication.Model.TestData.Rows.Count; i++) 
			{
                PdfStamper pst = null;
                MemoryStream mstr = null;
                using (mstr = new MemoryStream()) 
				{
                    try 
					{
                        PdfReader reader = new PdfReader(GetTemplateBytes());
                        pst = new PdfStamper(reader, mstr);
                        var acroFields = pst.AcroFields;
                        SetFieldsInternal(acroFields, 0);
                        pst.FormFlattening = true;
                        pst.SetFullCompression();
                    } finally 
					{
                        if (pst != null)
                            pst.Close();
                    }                    
                }
                pageBytes = mstr.ToArray();
                pagesAll.Add(pageBytes);
                
            }
        } finally 
		{
            
        }   
        
        Document doc = new Document(PageSize.A4);        
        var writer = PdfWriter.GetInstance(doc, Response.OutputStream);
        var copy2 = new PdfSmartCopy(doc, Response.OutputStream);
        doc.Open();
        doc.OpenDocument();
        
        foreach (var b in pagesAll) 
		{
            doc.NewPage();
            copy2.AddPage(copy2.GetImportedPage(new PdfReader(b), 1));
        }
        copy2.Close();
        watch.Stop();
        File.AppendAllText(context.Server.MapPath("~/App_Data/log.txt"), watch.Elapsed + Environment.NewLine);
                
    }
