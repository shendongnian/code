    using System;
    using System.Text;
    using System.Windows.Forms;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using System.IO;
    
    namespace Full_Profile1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            public static float CalculatePdfPTableHeight(PdfPTable table)
            {
                //Create a temporary PDF to calculate the height
                using (MemoryStream ms = new MemoryStream())
                {
                    using (Document doc = new Document(PageSize.TABLOID))
                    {
                        using (PdfWriter w = PdfWriter.GetInstance(doc, ms))
                        {
                            doc.Open();
    
                            table.WriteSelectedRows(0, table.Rows.Count, 0, 0, w.DirectContent);
    
                            doc.Close();
                            return table.TotalHeight;
                        }
                    }
                }
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                //Create our table
                PdfPTable t = new PdfPTable(2);
                //In order to use WriteSelectedRows you need to set the width of the table
                t.SetTotalWidth(new float[] { 200, 300 });
                t.AddCell("Hello");
                t.AddCell("World");
                t.AddCell("Test");
                t.AddCell("Test");
    
                //Calculate true height of the table so we can position it at the document's bottom
                float tableHeight = CalculatePdfPTableHeight(t);
                
                //Folder that we are working in
                string workingFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test");
    
                //PDF that we are creating
                string outputFile = Path.Combine(workingFolder, "Output.pdf");
    
                //Get an array of all JPEGs in the folder
                String[] AllImages = Directory.GetFiles(workingFolder, "*.jpg", SearchOption.TopDirectoryOnly);
    
                //Standard iTextSharp PDF init
                using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (Document document = new Document(PageSize.LETTER))
                    {
                        using (PdfWriter writer = PdfWriter.GetInstance(document, fs))
                        {
                            //Open our document for writing
                            document.Open();
    
                            //We do not want any margins in the document probably
                            document.SetMargins(0, 0, 0, 0);
    
                            //Declare here, init in loop below
                            iTextSharp.text.Image pageImage;
    
                            //Loop through each image
                            for (int i = 0; i < AllImages.Length; i++)
                            {
                                //If we only have one image or we are on the second to last one
                                if ((AllImages.Length == 1) | (i == (AllImages.Length - 1)))
                                {
                                    //Increase the size of the page by the height of the table
                                    document.SetPageSize(new iTextSharp.text.Rectangle(0, 0, document.PageSize.Width, document.PageSize.Height + tableHeight));
                                }
    
                                //Add a new page to the PDF
                                document.NewPage();
    
                                //Create our image instance
                                pageImage = iTextSharp.text.Image.GetInstance(AllImages[i]);
                                pageImage.ScaleToFit(document.PageSize.Width, document.PageSize.Height);
                                pageImage.Alignment = iTextSharp.text.Image.ALIGN_TOP | iTextSharp.text.Image.ALIGN_CENTER;
                                document.Add(pageImage);
    
                                //If we only have one image or we are on the second to last one
                                if ((AllImages.Length == 1) | (i == (AllImages.Length - 1)))
                                {
                                    //Draw the table to the bottom left corner of the document
                                    t.WriteSelectedRows(0, t.Rows.Count, 0, tableHeight, writer.DirectContent);
                                }
                                
                            }
    
                            //Close document for writing
                            document.Close();
                        }
                    }
                }
    
                this.Close();
            }
        }
    }
