    PdfReader reader = new PdfReader(new RandomAccessFileOrArray(Request.MapPath("Template.pdf")), null);
        Rectangle size = reader.GetPageSizeWithRotation(1);
        using (Stream outStream = Response.OutputStream)
        {
            Document document = new Document(size);
            PdfWriter writer = PdfWriter.GetInstance(document, outStream);
            document.Open();
            try
            {
                PdfContentByte cb = writer.DirectContent;
                cb.BeginText();
                try
                {
                    cb.SetFontAndSize(BaseFont.CreateFont(), 12);
                    cb.SetTextMatrix(110, 110);
                    cb.ShowText("aaa");
                }
                finally
                {
                    cb.EndText();
                }
                
                    PdfImportedPage page = writer.GetImportedPage(reader, 1);
                    cb.AddTemplate(page, 0, 0);
                
            }
            finally
            {
                document.Close();
                writer.Close();
                reader.Close();
            }
        }
