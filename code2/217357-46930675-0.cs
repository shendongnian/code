    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PdfSharp.Drawing;
    using PdfSharp.Pdf;
    using PdfSharp.Pdf.IO;
    
    namespace PDFTest
    {
        class Program
        {
            static Stream Main(string[] args)
            {
                using (PdfDocument originalDocument= PdfReader.Open("C:\\MainDocument.pdf", PdfDocumentOpenMode.Import))
                using (PdfDocument outputPdf = new PdfDocument())
                {
                    foreach (PdfPage page in originalDocument.Pages)
                    {
                        outPutPdf.AddPage(page);
                    }
                    var background = XImage.FromFile("C:\\Watermark.pdf");
                    foreach (PdfPage page in outputPdf.Pages)
                    {
                        XGraphics graphics = XGraphics.FromPdfPage(page);
                        graphics.DrawImage(background , Point.Empty);
    
                    }
                    MemoryStream stream = new MemoryStream();
                    outputPdf.Save("C:\\OutputFile.pdf");
                }
            }
        }
    }
