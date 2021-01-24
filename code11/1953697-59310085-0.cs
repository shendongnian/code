    void Main()
    {
        DateTime startTime;
        TimeSpan elapsedTime;
        int xy = 1000;
        try
        {
            for (int i = 1; i <= xy; i *= 10)
            {
                startTime = DateTime.Now;
                CreatePdf("D:\\Pcm Test", i);
                elapsedTime = (DateTime.Now - startTime);
    
                Console.WriteLine($"{i:d04} pages: {elapsedTime.TotalSeconds}.{elapsedTime.Milliseconds}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ": " + ex.StackTrace);
        }
        finally
        {
            Console.Read();
        }
    }
    
    public static void CreatePdf(String path, int numberOfPages)
    {
        PdfFont fontBold = PdfFontFactory.CreateFont(@"C:\Users\Aydin\Desktop\arialbd.ttf", true);
        PdfFont fontComic = PdfFontFactory.CreateFont(@"C:\Users\Aydin\Desktop\calibri.ttf", true);
        // Set up the document.     
    
        using (var rgbCSProfile = new FileStream(@"C:\Users\Aydin\Downloads\sRGB_CS_profile.icm", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        using (var pdfWriter = new PdfWriter($"{path}\\csharp_{numberOfPages}_pages.pdf"))
        {
            PdfADocument pdfDocument = new PdfADocument(pdfWriter, PdfAConformanceLevel.PDF_A_3B, new PdfOutputIntent("Custom", "", "http://www.color.org", "sRGB IEC61966-2.1", rgbCSProfile));
            pdfDocument.SetTagged();
            pdfDocument.GetDocumentInfo().SetTitle("Reference Document");
            pdfDocument.GetCatalog().SetViewerPreferences(new PdfViewerPreferences().SetDisplayDocTitle(true));
            pdfDocument.GetCatalog().SetLang(new PdfString("en-US"));
    
            Document document = new Document(pdfDocument);
    
            // Add a table to every page.
            for (int i = 0; i < numberOfPages; i++)
            {
    
                Table table = new Table(5, true);
                table.SetWidth(UnitValue.CreatePercentValue(100));
    
                document.Add(table);
    
                for (int j = 0; j < 5; j++)
                {
                    Cell cell = new Cell(2, 1)
                            .Add(new Paragraph("Header " + j).SetMultipliedLeading(0.5f))
                            .SetFont(fontBold)
                            .SetFontSize(20)
                            .SetBackgroundColor(ColorConstants.CYAN);
    
                    table.AddHeaderCell(cell);
                }
    
                for (int j = 0; j < 225; j++)
                {
                    if (j % 15 == 0) table.Flush();
                    
                    Cell cell = new Cell().Add(new Paragraph("Test " + j)
                                          .SetMultipliedLeading(0.5f))
                                          .SetFont(fontComic)
                                          .SetPaddingTop(4.1f);
    
                    table.AddCell(cell);
                }
    
                table.Complete();
                document.Flush();
                document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            }
            document.Close();
        }
    }
    // Define other methods and classes here
