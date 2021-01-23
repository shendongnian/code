    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.IO;
    using iTextSharp.text.pdf;
    using iTextSharp.text;
    
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
                //File to export to
                string exportFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "HTML.pdf");
    
                //Create our PDF document
                using (Document doc = new Document(PageSize.LETTER)){
                    using (FileStream fs = new FileStream(exportFile, FileMode.Create, FileAccess.Write, FileShare.Read)){
                        using (PdfWriter writer = PdfWriter.GetInstance(doc, fs)){
    
                            //Open the doc for writing
                            doc.Open();
    
                            //Insert a page
                            doc.NewPage();
                            
                            //This is our sample HTML
                            String HTML = "<ol><li>Row 1</li><li>Row 2</li></ol>";
    
                            //Create a StringReader to parse our text
                            using (StringReader sr = new StringReader(HTML))
                            {
                                //Pass our StringReader into iTextSharp's HTML parser, get back a list of iTextSharp elements
                                List<IElement> ies = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(sr, null);
    
                                //Loop through each element and add to the document
                                foreach (IElement ie in ies)
                                {
                                    doc.Add(ie);
                                }
                            }
                            //Close our document
                            doc.Close();
                        }
                    }
                }
            }
        }
    }
