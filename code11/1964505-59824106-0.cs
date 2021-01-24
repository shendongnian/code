     public static void ManipulatePdf(string src, string dest)
            {
                src = @"C:\CCPR Temp\TempFiles\PayStub_000106488_12282019_20200117112403.pdf";
                dest = @"C:\CCPR Temp\TempFiles\PayStub_WithStamper.pdf";
                PdfReader reader = new PdfReader(src);
                PdfStamper stamper = new PdfStamper(reader, new FileStream(dest, FileMode.Create)); // create?
                int numberOfPages = reader.NumberOfPages;
                Rectangle pagesize;
                for (int i = 1; i <= numberOfPages; i++)
                {
                    PdfContentByte under = stamper.GetUnderContent(i);
                    pagesize = reader.GetPageSize(i);
                    float x =40;// (pagesize.Left + pagesize.Right) / 2;
                    float y = pagesize.Top/4;// (pagesize.Bottom + pagesize.Top) / 2;
                    PdfGState gs = new PdfGState();
                    gs.FillOpacity = 1.0f;
                    under.SaveState();
                    under.SetGState(gs);
                    under.SetRGBColorFill(255,0,0); 
                    ColumnText.ShowTextAligned(under, Element.ALIGN_BOTTOM,
                        new Phrase("Watermark", new Font(Font.FontFamily.HELVETICA, 20)),
                        x, y, 1);
                    under.RestoreState();
                }
                stamper.Close();
                reader.Close();
            }
