     public static void RotatePDF(string inputFile, string outputFile)
        {
            using (FileStream outStream = new FileStream(outputFile, FileMode.Create))
            {
                iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(inputFile);
                iTextSharp.text.pdf.PdfStamper stamper = new iTextSharp.text.pdf.PdfStamper(reader, outStream);
                iTextSharp.text.pdf.PdfDictionary pageDict = reader.GetPageN(1);
                int desiredRot = 90; // 90 degrees clockwise from what it is now
                iTextSharp.text.pdf.PdfNumber rotation = pageDict.GetAsNumber(iTextSharp.text.pdf.PdfName.ROTATE);
                if (rotation != null)
                {
                    desiredRot += rotation.IntValue;
                    desiredRot %= 360; // must be 0, 90, 180, or 270
                }
                pageDict.Put(iTextSharp.text.pdf.PdfName.ROTATE, new iTextSharp.text.pdf.PdfNumber(desiredRot));
                stamper.Close();
            }
        }
