    using (PdfReader reader = new PdfReader(SOURCE_PDF))
    using (PdfWriter writer = new PdfWriter(TARGET_PDF))
    using (PdfDocument document = new PdfDocument(reader, writer))
    {
        for (int i = 1; i <= document.GetNumberOfPages(); i++)
        {
            PdfPage page = document.GetPage(i);
            Rectangle cropBox = page.GetCropBox();
            cropBox.SetWidth(cropBox.GetWidth() - 72);
            page.SetCropBox(cropBox);
        }
    }
