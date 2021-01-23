    using System;
    using System.Text;
    using System.Windows.Forms;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using System.IO;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
    
            //Folder that we are working in
            private static readonly string WorkingFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Hyperlinked PDFs");
            //Sample PDF
            private static readonly string BaseFile = Path.Combine(WorkingFolder, "OldFile.pdf");
            //Final file
            private static readonly string OutputFile = Path.Combine(WorkingFolder, "NewFile.pdf");
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                CreateSamplePdf();
                UpdatePdfLinks();
                this.Close();
            }
    
            private static void CreateSamplePdf()
            {
                //Create our output directory if it does not exist
                Directory.CreateDirectory(WorkingFolder);
    
                //Create our sample PDF
                using (iTextSharp.text.Document Doc = new iTextSharp.text.Document(PageSize.LETTER))
                {
                    using (FileStream FS = new FileStream(BaseFile, FileMode.Create, FileAccess.Write, FileShare.Read))
                    {
                        using (PdfWriter writer = PdfWriter.GetInstance(Doc, FS))
                        {
                            Doc.Open();
    
                            //Turn our hyperlink blue
                            iTextSharp.text.Font BlueFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLUE);
    
                            Doc.Add(new Paragraph(new Chunk("Go to URL", BlueFont).SetAction(new PdfAction("http://www.google.com/", false))));
    
                            Doc.Close();
                        }
                    }
                }
            }
    
            private static void UpdatePdfLinks()
            {
                //Setup some variables to be used later
                PdfReader R = default(PdfReader);
                int PageCount = 0;
                PdfDictionary PageDictionary = default(PdfDictionary);
                PdfArray Annots = default(PdfArray);
    
                //Open our reader
                R = new PdfReader(BaseFile);
                //Get the page cont
                PageCount = R.NumberOfPages;
    
                //Loop through each page
                for (int i = 1; i <= PageCount; i++)
                {
                    //Get the current page
                    PageDictionary = R.GetPageN(i);
    
                    //Get all of the annotations for the current page
                    Annots = PageDictionary.GetAsArray(PdfName.ANNOTS);
    
                    //Make sure we have something
                    if ((Annots == null) || (Annots.Length == 0))
                        continue;
    
                    //Loop through each annotation
    
                    foreach (PdfObject A in Annots.ArrayList)
                    {
                        //Convert the itext-specific object as a generic PDF object
                        PdfDictionary AnnotationDictionary = (PdfDictionary)PdfReader.GetPdfObject(A);
    
                        //Make sure this annotation has a link
                        if (!AnnotationDictionary.Get(PdfName.SUBTYPE).Equals(PdfName.LINK))
                            continue;
    
                        //Make sure this annotation has an ACTION
                        if (AnnotationDictionary.Get(PdfName.A) == null)
                            continue;
    
                        //Get the ACTION for the current annotation
                        PdfDictionary AnnotationAction = (PdfDictionary)AnnotationDictionary.Get(PdfName.A);
    
                        //Test if it is a URI action
                        if (AnnotationAction.Get(PdfName.S).Equals(PdfName.URI))
                        {
                            //Change the URI to something else
                            AnnotationAction.Put(PdfName.URI, new PdfString("http://www.bing.com/"));
                        }
                    }
                }
    
                //Next we create a new document add import each page from the reader above
                using (FileStream FS = new FileStream(OutputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (Document Doc = new Document())
                    {
                        using (PdfCopy writer = new PdfCopy(Doc, FS))
                        {
                            Doc.Open();
                            for (int i = 1; i <= R.NumberOfPages; i++)
                            {
                                writer.AddPage(writer.GetImportedPage(R, i));
                            }
                            Doc.Close();
                        }
                    }
                }
            }
        }
    }
