    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using System.IO;
    
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
                //Create a new document
                iTextSharp.text.Document Doc = new iTextSharp.text.Document(PageSize.LETTER);
    
                //Write it to a memory stream
                using (FileStream FS = new FileStream(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), "Output.pdf"), FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    object writer = PdfWriter.GetInstance(Doc, FS);
    
                    //Open the PDF for writing
                    Doc.Open();
    
                    //Insert a page
                    Doc.NewPage();
    
                    //Add a phrase with an ampersand
                    Doc.Add(new Phrase("Hello & Goodbye"));
    
                    //Create some HTML with an escaped and also unescaped ampersand
                    string Html = "<html><head><title></title></head><body><p>This is an escaped ampersand : &amp;</p><p>And this is a non-escaped ampersand : &</body></html";
    
                    //Read the HTML in a StringRead
                    using (StringReader SR = new StringReader(Html))
                    {
                        //Grab the elements
                        List<IElement> elements = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(SR, null);
    
                        //Loop through them
                        for (int i = 0; i < elements.Count; i++)
                        {
                            //Add them to the document
                            Doc.Add(elements[i]);
                        }
                    }
    
                    //Close the PDF
                    Doc.Close();
                }
                this.Close();
            }
        }
    }
