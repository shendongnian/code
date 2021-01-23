    using System;
    using System.ComponentModel;
    using System.Text;
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
                //PDF file to pull the first page from
                string inputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Input.pdf");
                //PDF file to output
                string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Output.pdf");
    
    
                using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (Document doc = new Document())
                    {
                        using (PdfWriter w = PdfWriter.GetInstance(doc, fs))
                        {
                            //Open our PDF for writing
                            doc.Open();
    
                            //We need a reader to pull pages from
                            PdfReader r = new PdfReader(inputFile);
    
                            //Get the first page of our source PDF
                            PdfImportedPage importedPage = w.GetImportedPage(r, 1);
    
                            //Insert a new page into our output PDF
                            doc.NewPage();
    
                            //Create an Image from the imported page
                            iTextSharp.text.Image Img = iTextSharp.text.Image.GetInstance(importedPage);
    
                            //Just to show why we are using an Image, scale the Image to 50% width and height of the original page
                            Img.ScaleAbsolute(importedPage.Width / 2, importedPage.Height / 2);
    
                            //Add the Image to the page
                            doc.Add(Img);
    
                            //Close our output PDF
                            doc.Close();
                        }
                    }
                }
                this.Close();
            }
        }
    }
