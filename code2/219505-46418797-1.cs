    using iTextSharp.text;
    using iTextSharp.text.pdf;
    public void pdfcopyfile()
        {
            string pdfTemplatePath = @"D:\1.pdf";
            string outputPdfPath = @"D:\44.pdf";
            iTextSharp.text.pdf.PdfReader reader = null;
            int pageCount = 0;
            int currentPage = 0;
            Document pdfDoc = null;
            PdfCopy writer = null;
            PdfImportedPage page = null;
            reader = new PdfReader(pdfTemplatePath);
            pdfDoc = new Document(reader.GetPageSizeWithRotation(1));
            writer = new PdfCopy(pdfDoc, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));
            pageCount = reader.NumberOfPages;
            pdfDoc.Open();
            while (currentPage < pageCount)
            {
                currentPage += 1;
                pdfDoc.SetPageSize(reader.GetPageSizeWithRotation(currentPage));
                pdfDoc.NewPage();
                page = writer.GetImportedPage(reader, currentPage);
                writer.AddPage(page);
            }
            reader = new PdfReader(pdfTemplatePath);
            pageCount = reader.NumberOfPages;
            currentPage = 0;
            pdfDoc.Close();
        }
