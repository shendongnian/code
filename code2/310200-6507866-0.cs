    using System;
    using System.Windows.Forms;
    using System.IO;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
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
                //Folder that we will be working in
    
                string WorkingFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Big File PDF Test");
    
                //Base name of PDFs that we will be creating
                string BigFileBase = Path.Combine(WorkingFolder, "BigFile");
    
                //Final combined PDF name
                string CombinedFile = Path.Combine(WorkingFolder, "Combined.pdf");
    
                //Number of "large" files to create
                int NumberOfBigFilesToMakes = 10;
    
                //Number of pages to put in the files
                int NumberOfPagesInBigFile = 1000;
    
                //Number of pages to insert into combined file
                int NumberOfPagesToInsertIntoCombinedFile = 500;
    
                //Create our test directory
                if (!Directory.Exists(WorkingFolder)) Directory.CreateDirectory(WorkingFolder);
    
                //First step, create a bunch of files with a bunch of pages, hopefully code is self-explanatory
                for (int FileCount = 1; FileCount <= NumberOfBigFilesToMakes; FileCount++)
                {
                    using (FileStream FS = new FileStream(BigFileBase + FileCount + ".pdf", FileMode.Create, FileAccess.Write, FileShare.Read))
                    {
                        using (iTextSharp.text.Document Doc = new iTextSharp.text.Document(PageSize.LETTER))
                        {
                            using (PdfWriter writer = PdfWriter.GetInstance(Doc, FS))
                            {
                                Doc.Open();
                                for (int I = 1; I <= NumberOfPagesInBigFile; I++)
                                {
                                    Doc.NewPage();
                                    Doc.Add(new Paragraph("This is file " + FileCount));
                                    Doc.Add(new Paragraph("This is page " + I));
                                }
                                Doc.Close();
                            }
                        }
                    }
                }
    
                //Second step, loop around pulling random pages from random files
    
                //Create our output file
                using (FileStream FS = new FileStream(CombinedFile, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    using (Document Doc = new Document())
                    {
                        using (PdfCopy pdfCopy = new PdfCopy(Doc, FS))
                        {
                            Doc.Open();
    
                            //Setup some variables to use in the loop below
                            PdfReader reader = null;
                            PdfImportedPage page = null;
                            int RanFileNum = 0;
                            int RanPageNum = 0;
    
                            //Standard random number generator
                            Random R = new Random();
    
                            for (int I = 1; I <= NumberOfPagesToInsertIntoCombinedFile; I++)
                            {
                                //Just to output our current progress
                                Console.WriteLine(I);
    
                                //Get a random page and file. Remember iText pages are 1-based.
                                RanFileNum = R.Next(1, NumberOfBigFilesToMakes + 1);
                                RanPageNum = R.Next(1, NumberOfPagesInBigFile + 1);
    
                                //Open the random file
                                reader = new PdfReader(BigFileBase + RanFileNum + ".pdf");
                                //Set the current page
                                Doc.SetPageSize(reader.GetPageSizeWithRotation(1));
    
                                //Grab a random page
                                page = pdfCopy.GetImportedPage(reader, RanPageNum);
                                //Add it to the combined file
                                pdfCopy.AddPage(page);
    
                                //Clean up
                                reader.Close();
                            }
    
                            //Clean up
                            Doc.Close();
                        }
                    }
                }
    
            }
        }
    }
