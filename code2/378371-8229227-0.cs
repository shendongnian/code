    using System;
    using System.Text;
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
                //The names of the two files that we'll create
                string File1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "File1.pdf");
                string File2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "File2.pdf");
    
                //Create a test file to merge into the second file
                using (FileStream fs = new FileStream(File1, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    //We'll create this one landscape to show some checks that need to be done later
                    using (Document doc = new Document(PageSize.TABLOID.Rotate()))
                    {
                        using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                        {
                            doc.Open();
                            doc.Add(new Paragraph("File 1"));
                            doc.Close();
                        }
                    }
                }
    
                //Create our second file
                using (FileStream fs = new FileStream(File2, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    //Create this one as a regular US Letter portrait sized document
                    using (Document doc = new Document(PageSize.LETTER))
                    {
                        using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                        {
                            doc.Open();
    
                            doc.Add(new Paragraph("File 2"));
    
                            //Create a PdfReader to read our first file
                            PdfReader r = new PdfReader(File1);
    
                            //Store the number of pages
                            int pageCount = r.NumberOfPages;
    
                            //Variables which will be set in the loop below
                            iTextSharp.text.Rectangle rect;
                            PdfImportedPage imp;
                            
                            //Loop through each page in the source document, remember that page indexes start a one and not zero
                            for (int i = 1; i <= pageCount; i++)
                            {
                                //Get the page's dimension and rotation
                                rect = r.GetPageSizeWithRotation(i);
    
                                //Get the actual page
                                imp = writer.GetImportedPage(r, i);
    
                                //These two commands must happen in this order
                                //First change the "default page size" to match the current page's size
                                doc.SetPageSize(rect);
                                //then add a new blank page which we'll fill with our actual page
                                doc.NewPage();
                                
                                //If the document has been rotated one twist left or right (90 degrees) then we need to add it a little differently
                                if (rect.Rotation == 90 || rect.Rotation == 270)
                                {
                                    //Add the page accounting for the rotation
                                    writer.DirectContent.AddTemplate(imp, 0, -1, 1, 0, 0, rect.Height);
                                }
                                else
                                {
                                    //Add the page normally
                                    writer.DirectContent.AddTemplate(imp, 0, 0);
                                }
                                
                            }
    
                            doc.Close();
                        }
                    }
                }
                this.Close();
            }
        }
    }
