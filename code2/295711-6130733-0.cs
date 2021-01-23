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
    
                Document Doc = new Document(PageSize.LETTER);
    
                //Create our file stream
                using (FileStream fs = new FileStream(@"C:\Users\moshe\Desktop\Test18.pdf", FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    //Bind PDF writer to document and stream
                    PdfWriter writer = PdfWriter.GetInstance(Doc, fs);
    
                    //Open document for writing
                    Doc.Open();
    
                    //Add a page
                    Doc.NewPage();
    
                    //Full path to the Arial file
                    string ARIALUNI_TFF = Path.Combine(@"C:\Users\moshe\Desktop\proj\gold\fop\gold", "ARIAL.TTF");
    
                    //Create a base font object making sure to specify IDENTITY-H
                    BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
    
                    //Create a specific font object
                    iTextSharp.text.Font f = new iTextSharp.text.Font(bf, 12);
    
                    //Use a table so that we can set the text direction
                    PdfPTable T = new PdfPTable(1);
                    //Hide the table border
                    T.DefaultCell.BorderWidth = 0;
                    //Set RTL mode
                    T.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    //Add our text
                    T.AddCell(new Phrase("מה קורה", f));
    
                    //Add table to document
                    Doc.Add(T);
    
                    //Close the PDF
                    Doc.Close();
    
                }
            }
        }
    }
