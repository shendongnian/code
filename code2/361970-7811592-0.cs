    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using Microsoft.Office.Interop.Word;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                Microsoft.Office.Interop.Word._Application oWord = new Application();
                oWord.Visible = true;
    
                var oDoc = oWord.Documents.Add();
    
                //Insert a paragraph at the beginning of the document.
                var paragraph1 = oDoc.Content.Paragraphs.Add();
    
                paragraph1.Range.Text = "Heading 1";
                paragraph1.Range.Font.Bold = 1;
                paragraph1.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.
    
                oDoc.SaveAs2(@"C:\Temp\TestDocumentWith1Paragraph.docx");
    
                oWord.Quit();
            }
        }
    }
