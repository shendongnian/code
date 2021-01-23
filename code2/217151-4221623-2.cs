    string contents = string.Empty();
    Document doc = new Document();
    PdfReader reader = new PdfReader("pathToPdf.pdf");
    using (MemoryStream memoryStream = new MemoryStream())
    {
        PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
        doc.Open();
        PdfContentByte cb = writer.DirectContent;
        for (int p = 1; p <= reader.NumberOfPages; p++)
        {
            // add page from reader
            doc.SetPageSize(reader.GetPageSize(p));
            doc.NewPage();
            // pickup here something like this:
            byte[] bt = reader.GetPageContent(p);
            contents = ExtractTextFromPDFBytes(bt);
            if (contents.IndexOf("something")!=-1)
            {
                // make your own pdf page and add to cb (contentbyte)
  
            }
            else
            {
                PdfImportedPage page = writer.GetImportedPage(reader, p);
                int rot = reader.GetPageRotation(p);
                if (rot == 90 || rot == 270)
                    cb.AddTemplate(page, 0, -1.0F, 1.0F, 0, 0, reader.GetPageSizeWithRotation(p).Height);
                else
                    cb.AddTemplate(page, 1.0F, 0, 0, 1.0F, 0, 0);
            }
        }
        reader.Close();
        doc.Close();
        File.WriteAllBytes("pathToOutputOrSamePathToOverwrite.pdf", memoryStream.ToArray());
