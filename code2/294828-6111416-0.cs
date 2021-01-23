    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using System.IO;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Create our document object
                Document Doc = new Document(PageSize.LETTER);
    
                //Create our file stream
                using (FileStream fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.pdf"), FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    //Bind PDF writer to document and stream
                    PdfWriter writer = PdfWriter.GetInstance(Doc, fs);
    
                    //Open document for writing
                    Doc.Open();
    
                    //Add a page
                    Doc.NewPage();
    
                    //Full path to the Unicode Arial file
                    string ARIALUNI_TFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");
    
                    //Create a base font object making sure to specify IDENTITY-H
                    BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
    
                    //Create a specific font object
                    Font f = new Font(bf, 12, Font.NORMAL);
    
                    //Write some text, the last character is 0x0278 - LATIN SMALL LETTER PHI
                    Doc.Add(new Phrase("This is a test ɸ", f));
    
                    //Write some more text, the last character is 0x0682 - ARABIC LETTER HAH WITH TWO DOTS VERTICAL ABOVE
                    Doc.Add(new Phrase("Hello\u0682", f));
    
                    //Close the PDF
                    Doc.Close();
                }
            }
        }
    }
