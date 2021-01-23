    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using iTextSharp.text.pdf;
    using iTextSharp.text;
    
    
    namespace Full_Profile1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                //The files that we are working with
                string sourceFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string sourceFile = Path.Combine(sourceFolder, "Test.pdf");
                string destFile = Path.Combine(sourceFolder, "TestOutput.pdf");
    
                //Remove all pages except 1,2,3,4 and 6
                removePagesFromPdf(sourceFile, destFile, 1, 2, 3, 4, 6);
                this.Close();
            }
            public void removePagesFromPdf(String sourceFile, String destinationFile, params int[] pagesToKeep)
            {
                //Used to pull individual pages from our source
                PdfReader r = new PdfReader(sourceFile);
                //Create our destination file
                using (FileStream fs = new FileStream(destinationFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (Document doc = new Document())
                    {
                        using (PdfWriter w = PdfWriter.GetInstance(doc, fs))
                        {
                            //Open the desitination for writing
                            doc.Open();
                            //Loop through each page that we want to keep
                            foreach (int page in pagesToKeep)
                            {
                                //Add a new blank page to destination document
                                doc.NewPage();
                                //Extract the given page from our reader and add it directly to the destination PDF
                                w.DirectContent.AddTemplate(w.GetImportedPage(r, page), 0, 0);
                            }
                            //Close our document
                            doc.Close();
                        }
                    }
                }
            }
        }
    }
