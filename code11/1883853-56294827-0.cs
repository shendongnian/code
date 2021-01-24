    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using iTextSharp;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using Font = iTextSharp.text.Font;
    
    namespace ConsoleApp1
    {
        class Program
        {
             public static void AddPageNumber(string fileIn, string fileOut)
             {
                 byte[] bytes = File.ReadAllBytes(fileIn);
                 Font blackFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                 using (MemoryStream stream = new MemoryStream())
                 {
                     PdfReader reader = new PdfReader(bytes);
                     using (PdfStamper stamper = new PdfStamper(reader, stream))
                     {
                         int pages = reader.NumberOfPages;
                         for (int i = 1; i <= pages; i++)
                         {
                             //ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase(i.ToString(), blackFont), 568f, 15f, 0);
                             ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase(String.Format("Page " +i+ " of " + pages.ToString())), 568f, 15f, 0);
                         }
                     }
                     bytes = stream.ToArray();
                 }
                 File.WriteAllBytes(fileOut, bytes);
             }
             
            static void Main(string[] args)
            {
                string inputPdfString = @"C:\Users\*************\Desktop\Doc1.pdf";
                string outputResultString = @"C:\Users\************\Desktop\Doc2Out.pdf";
                AddPageNumber(inputPdfString,outputResultString);
                Console.WriteLine("Finished!");
                Console.Read();
            }
        }
    }
