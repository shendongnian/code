     const string filename = "C:/Temp/test.docx";
            Response.ContentEncoding = System.Text.Encoding.UTF7;
            System.Text.StringBuilder SB = new System.Text.StringBuilder();
            System.IO.StringWriter SW = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlTW = new System.Web.UI.HtmlTextWriter(SW);
            tbl.RenderControl(htmlTW);
           string strBody = "<html>" +
            "<body>" + "<div><b>" + htmlTW.InnerWriter.ToString() + "</b></div>" +
              "</body>" +
             "</html>";
            string html = strBody;
            if (File.Exists(filename)) File.Delete(filename);
            using (MemoryStream generatedDocument = new MemoryStream())
            {
                using (WordprocessingDocument package = WordprocessingDocument.Create(generatedDocument, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = package.MainDocumentPart;
                    if (mainPart == null)
                    {
                        mainPart = package.AddMainDocumentPart();
                        new Document(new Body()).Save(mainPart);
                    }
                    
                    HtmlConverter converter = new HtmlConverter(mainPart);
                    converter.BaseImageUrl = new Uri("http://localhost:portnumber/");
                    Body body = mainPart.Document.Body;
                   
                    var paragraphs = converter.Parse(html);
                    for (int i = 0; i < paragraphs.Count; i++)
                    {
                        body.Append(paragraphs[i]);
                    }
                    mainPart.Document.Save();
                }
                File.WriteAllBytes(filename, generatedDocument.ToArray());
            }
            System.Diagnostics.Process.Start(filename);
        
