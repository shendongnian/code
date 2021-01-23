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
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                //Test file name
                string TestFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.pdf");
    
                //Standard iTextSharp setup
                using (FileStream fs = new FileStream(TestFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (Document doc = new Document(PageSize.LETTER))
                    {
                        using (PdfWriter w = PdfWriter.GetInstance(doc, fs))
                        {
                            //Open the document for writing
                            doc.Open();
    
                            //Create a shading object. The (x,y)'s appear to be document-level instead of cell-level so they need to be played with
                            PdfShading shading = PdfShading.SimpleAxial(w, 0, 700, 300, 700, BaseColor.BLUE, BaseColor.RED);
    
                            //Create a pattern from our shading object
                            PdfShadingPattern pattern = new PdfShadingPattern(shading);
    
                            //Create a color from our patter
                            ShadingColor color = new ShadingColor(pattern);
    
                            //Create a standard two column table
                            PdfPTable t = new PdfPTable(2);
    
                            //Add a text cell setting the background color through object initialization
                            t.AddCell(new PdfPCell(new Phrase("Hello")) { BackgroundColor = color });
    
                            //Add another cell with everything inline. Notice that the (x,y)'s have been updated
                            t.AddCell(new PdfPCell(new Phrase("World")) { BackgroundColor = new ShadingColor(new PdfShadingPattern(PdfShading.SimpleAxial(w, 400, 700, 600, 700, BaseColor.PINK, BaseColor.CYAN))) });
                            
    
    
                            //Add the table to the document
                            doc.Add(t);
    
                            //Close the document
                            doc.Close();
                        }
                    }
                }
    
                this.Close();
            }
    
        }
    }
