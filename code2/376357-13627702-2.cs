       class AbcPrintEmf
    {
        private Doc mDoc;
        private string mJobName;
        private string mPrinterName;
        private string mTempFilePath;
        private bool mRenderTextAsPolygon;
        public AbcPdfPrinterApproach(Doc printMe, string jobName, string printerName, bool debug, string tempFilePath, bool renderTextAsPolygon)
        {
            mDoc = printMe;
            mDoc.PageNumber = 1;
            mJobName = jobName;
            mPrinterName = printerName;
            mRenderTextAsPolygon = renderTextAsPolygon;
            if (debug)
                mTempFilePath = tempFilePath;
        }
        public void print()
        {
            using (PrintDocument pd = new PrintDocument())
            {
                pd.DocumentName = this.mJobName;
                pd.PrinterSettings.PrinterName = this.mPrinterName;
                pd.PrintController = new StandardPrintController();
                pd.PrintPage += new PrintPageEventHandler(DoPrintPage);
                pd.Print();
            }
        }
        private void DoPrintPage(object sender, PrintPageEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                if (mDoc.PageCount == 0) return;
                if (mDoc.Page == 0) return;
                XRect cropBox = mDoc.CropBox;
                double srcWidth = (cropBox.Width / 72) * 100;
                double srcHeight = (cropBox.Height / 72) * 100;
                double pageWidth = e.PageBounds.Width;
                double pageHeight = e.PageBounds.Height;
                double marginX = e.PageSettings.HardMarginX;
                double marginY = e.PageSettings.HardMarginY;
                double dstWidth = pageWidth - (marginX * 2);
                double dstHeight = pageHeight - (marginY * 2);
                // if source bigger than destination then scale
                if ((srcWidth > dstWidth) || (srcHeight > dstHeight))
                {
                    double sx = dstWidth / srcWidth;
                    double sy = dstHeight / srcHeight;
                    double s = Math.Min(sx, sy);
                    srcWidth *= s;
                    srcHeight *= s;
                }
                // now center
                double x = (pageWidth - srcWidth) / 2;
                double y = (pageHeight - srcHeight) / 2;
                // save state
                RectangleF theRect = new RectangleF((float)x, (float)y, (float)srcWidth, (float)srcHeight);
                int theRez = e.PageSettings.PrinterResolution.X;
                // draw content
                mDoc.Rect.SetRect(cropBox);
                mDoc.Rendering.DotsPerInch = theRez;
                mDoc.Rendering.ColorSpace = "RGB";
                mDoc.Rendering.BitsPerChannel = 8;
                if (mRenderTextAsPolygon)
                {
                    //i.e. render text as polygon (non default)
                    mDoc.SetInfo(0, "RenderTextAsText", "0");
                }
                byte[] theData = mDoc.Rendering.GetData(".emf");
                if (mTempFilePath != null)
                {
                    File.WriteAllBytes(mTempFilePath + @"\" + mDoc.PageNumber + ".emf", theData);
                }
                using (MemoryStream theStream = new MemoryStream(theData))
                {
                    using (Metafile theEMF = new Metafile(theStream))
                    {
                        g.DrawImage(theEMF, theRect);
                    }
                }
                e.HasMorePages = mDoc.PageNumber < mDoc.PageCount;
                if (!e.HasMorePages) return;
                //increment to next page, corrupted PDF's have occasionally failed to increment
                //which would otherwise put us in a spooling infinite loop, which is bad, so this check avoids it
                int oldPageNumber = mDoc.PageNumber;
                ++mDoc.PageNumber;
                int newPageNumber = mDoc.PageNumber;
                if ((oldPageNumber + 1) != newPageNumber)
                {
                    throw new Exception("PDF cannot be printed as it is corrupt, pageNumbers will not increment properly.");
                }
            }
        }
    }
