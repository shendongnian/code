    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    
    namespace iTextTest
    {
        class Program
        {
                            /** The original PDF file. */
            const String Original = @"C:\Jobs\InvoiceSource.pdf";
            const String Background = @"C:\Jobs\InvoiceTemplate.pdf";
            const String Result = @"C:\Jobs\InvoiceOutput.pdf";
    
            static void Main(string[] args)
            {
                ManipulatePdf(Original, Background, Result);
            }
    
            static void ManipulatePdf(String src, String stationery, String dest)
            {
                // Create readers
                PdfReader reader = new PdfReader(src);
                PdfReader sReader = new PdfReader(stationery);
                // Create the stamper
                PdfStamper stamper = new PdfStamper(reader, new FileStream(dest, FileMode.Create));
                // Add the stationery to each page
                PdfImportedPage page = stamper.GetImportedPage(sReader, 1);
                int n = reader.NumberOfPages;
                PdfContentByte background;
                for (int i = 1; i <= n; i++)
                {
                    background = stamper.GetUnderContent(i);
                    background.AddTemplate(page, 0, 0);
                }
                // CLose the stamper
                stamper.Close();
            }
    
    
        }
    }
    
