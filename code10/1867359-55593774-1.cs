        public string AddWatermark(string fileLocation)
        {
            string watermarkLocation = AppDomain.CurrentDomain.BaseDirectory + "Watermark.png";
            Document document = new Document();
            PdfReader pdfReader = new PdfReader(fileLocation);
            PdfReader pdfFlatten = new PdfReader(FlattenPdfFormToBytes(pdfReader)); // The secret sauce is this!!!
            PdfStamper stamp = new PdfStamper(pdfFlatten, new FileStream(fileLocation.Replace(".pdf", "_marked.pdf"), FileMode.Create));
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(watermarkLocation);
            img.ScaleToFit(document.PageSize);
            img.SetAbsolutePosition(0, 100);
            PdfContentByte waterMark;
            for (int page = 1; page <= pdfFlatten.NumberOfPages; page++)
            {
                waterMark = stamp.GetOverContent(page);
                waterMark.AddImage(img);
            }
            stamp.Close();
            return fileLocation.Replace(".pdf", "_marked.pdf");
        }
