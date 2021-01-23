    using System;
    using System.IO;
    using org.apache.pdfbox.pdmodel;
    using org.apache.pdfbox.util;
    namespace testPDF
    {
    class Program
    {
        static void Main()
        {
            PDFtoText pdf = new PDFtoText();
            string pdfText = pdf.parsePDF(@"C:\Sample.pdf");
            using (StreamWriter writer = new StreamWriter(@"C:\Sample.txt"))
            { writer.Write(pdfText); }
        }
        class PDFtoText
        {
            public string parsePDF(string filepath)
            {
                PDDocument document = PDDocument.load(filepath);
                PDFTextStripper stripper = new PDFTextStripper();
                return stripper.getText(document);
            }
        }
    }
    }
