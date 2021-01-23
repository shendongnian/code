    using System;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
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
                string workingFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string outputFile = Path.Combine(workingFolder, "Test.pdf");
                string checkedImagePath = Path.Combine(workingFolder, "checked.png");
                string uncheckedImagePath = Path.Combine(workingFolder, "unchecked.png");
    
                using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (Document doc = new Document(PageSize.LETTER))
                    {
                        using (PdfWriter w = PdfWriter.GetInstance(doc, fs))
                        {
                            //Open our document for writing
                            doc.Open();
    
                            //Create images from our file paths
                            var chkchecked = iTextSharp.text.Image.GetInstance(checkedImagePath);
                            var chkunchecked = iTextSharp.text.Image.GetInstance(uncheckedImagePath);
    
                            //Scale the images to an appropriate size (if needed)
                            chkchecked.ScaleAbsolute(12, 12);
                            chkunchecked.ScaleAbsolute(12, 12);
    
                            //Create a Paragraph object to contain our images and text
                            Paragraph p = new Paragraph();
    
                            //Add an image
                            p.Add(new Chunk(chkchecked, 0, 0));
    
                            //Add some text
                            p.Add("checked");
    
                            //Add another image
                            p.Add(new Chunk(chkunchecked, 0, 0));
    
                            //Add some more text
                            p.Add("checked");
    
                            //Create a one column table
                            PdfPTable table = new PdfPTable(1);
    
                            //Create a cell for the table
                            PdfPCell cell = new PdfPCell();
    
                            //Add the paragraph to the cell
                            cell.AddElement(p);
    
                            //Add the cell to the table
                            table.AddCell(cell);
    
                            //Add the table to the document
                            doc.Add(table);
    
                            //Close the document
                            doc.Close();
                        }
                    }
                }
                this.Close();
            }
        }
    }
