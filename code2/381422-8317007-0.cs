        /// <summary>
        /// Saves the entire manual as PDF
        /// </summary>
        public static void createEntireManual(string PDFPath)
        {
            Document d = new Document();
            PdfWriter.GetInstance(d, new FileStream(PDFPath, FileMode.Create));
            d.Open();
            d.SetPageSize(iTextSharp.text.PageSize.A4);
            Image Cover = Image.GetInstance(Settings.ManualBinLocation + "cover.png");
            Cover.SetAbsolutePosition(0, 0);
            d.Add(Cover);
            d.Close();              
        }
