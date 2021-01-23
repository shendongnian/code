     public void pdfcopyfile()
        {
            string pdfTemplatePath = @"D:\1.pdf";
            string outputPdfPath = @"D:\44.pdf";
            int pageCount = 0;
            PdfImportedPage page = null;
            PdfReader reader = new PdfReader(pdfTemplatePath);
            Document pdfDoc = new Document(reader.GetPageSizeWithRotation(1));
            PdfCopy writer = new PdfCopy(pdfDoc, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));
            pageCount = reader.NumberOfPages;
            int currentPage = 0;
            while (currentPage < pageCount)
            {
                currentPage += 1;
                pdfDoc.SetPageSize(reader.GetPageSizeWithRotation(currentPage));
                pdfDoc.NewPage();
                page = writer.GetImportedPage(reader, currentPage);
                writer.AddPage(page);
            }
            reader = new iTextSharp.text.pdf.PdfReader(pdfTemplatePath);
            pageCount = reader.NumberOfPages;
            currentPage = 0;
            pdfDoc.Close();
        }
