    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using iTextSharp.text.pdf.parser;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                string InputFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Input.pdf");
    
                //Get all the text
                string T = ExtractAllTextFromPdf(InputFile);
                //Count the words
                int I = GetWordCountFromString(T);
    
            }
    
            public static string ExtractAllTextFromPdf(string inputFile)
            {
                //Sanity checks
                if (string.IsNullOrEmpty(inputFile))
                    throw new ArgumentNullException("inputFile");
                if (!System.IO.File.Exists(inputFile))
                    throw new System.IO.FileNotFoundException("Cannot find inputFile", inputFile);
    
                //Create a stream reader (not necessary but I like to control locks and permissions)
                using (FileStream SR = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    //Create a reader to read the PDF
                    iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(SR);
    
                    //Create a buffer to store text
                    StringBuilder Buf = new StringBuilder();
    
                    //Use the PdfTextExtractor to get all of the text on a page-by-page basis
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        Buf.AppendLine(PdfTextExtractor.GetTextFromPage(reader, i));
                    }
    
                    return Buf.ToString();
                }
            }
            public static int GetWordCountFromString(string text)
            {
                //Sanity check
                if (string.IsNullOrEmpty(text))
                    return 0;
    
                //Count the words
                return System.Text.RegularExpressions.Regex.Matches(text, "\\S+").Count;
            }
        }
    }
