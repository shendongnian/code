    using (PdfReader pdfReader = new PdfReader(SOURCE_PDF))
    {
        for (int i = 1; i <= pdfReader.NumberOfPages; i++)
        {
            Rectangle mediaBox = pdfReader.GetPageSize(i);
            if (mediaBox.Left == 0 && mediaBox.Bottom == 0)
                continue;
            PdfDictionary pageDict = pdfReader.GetPageN(i);
            pageDict.Put(PdfName.MEDIABOX, new PdfArray { new PdfNumber(0), new PdfNumber(0),
                new PdfNumber(mediaBox.Width), new PdfNumber(mediaBox.Height) });
            Rectangle cropBox = pdfReader.GetBoxSize(i, "crop");
            if (cropBox != null)
            {
                pageDict.Put(PdfName.CROPBOX, new PdfArray { new PdfNumber(cropBox.Left - mediaBox.Left),
                    new PdfNumber(cropBox.Bottom-mediaBox.Bottom), new PdfNumber(cropBox.Right - mediaBox.Left),
                    new PdfNumber(cropBox.Top - mediaBox.Bottom) });
            }
            using (MemoryStream stream = new MemoryStream())
            {
                string translation = String.Format(CultureInfo.InvariantCulture, "1 0 0 1 {0} {1} cm\n", -mediaBox.Left, -mediaBox.Bottom);
                byte[] translationBytes = Encoding.ASCII.GetBytes(translation);
                stream.Write(translationBytes, 0, translationBytes.Length);
                byte[] contentBytes = pdfReader.GetPageContent(i);
                stream.Write(contentBytes, 0, contentBytes.Length);
                pdfReader.SetPageContent(i, stream.ToArray());
            }
        }
        using (FileStream fileStream = new FileStream(@"MediaBox-normalized.pdf", FileMode.Create))
        using (PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream))
        {
        }
    }
