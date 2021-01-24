     public void AddPageNumberToPDF(string physicalDocPath, bool showPageOfPage)
            {
                byte[] Fbytes = File.ReadAllBytes(physicalDocPath);
                PdfReader reader = new PdfReader(Fbytes);
                int n = reader.NumberOfPages;
                using (var fileStream = new FileStream(physicalDocPath, FileMode.Create, FileAccess.Write))
                {
                    var document = new Document(reader.GetPageSizeWithRotation(1));
                    var writer = PdfWriter.GetInstance(document, fileStream);
                    document.Open();
                    PdfContentByte cb = writer.DirectContent;
                    int p = 0;
    
                    for (int page = 1; page <= reader.NumberOfPages; page++)
                    {
                        document.NewPage();
                        p++;
    
                        PdfImportedPage importedPage = writer.GetImportedPage(reader, page);
                        cb.AddTemplate(importedPage, 0, 0);
    
                        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        cb.BeginText();
                        cb.SetFontAndSize(bf, 10);
                        if (showPageOfPage)
                        {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, p.ToString()+"/"+n.ToString(), 575, 17, 0);
                        }
                        else
                        {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, p.ToString(), 575, 17, 0);
                        }
                        
                        cb.EndText();
                    }
    
                    document.Close();
                    writer.Close();
                }
            }
