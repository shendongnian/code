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
    
                            //Will hold our current x,y coordinates;
                            float curY;
                            float curX;
    
                            //Add a paragraph
                            doc.Add(new Paragraph("It was the best of times"));
    
                            //Get the current Y value
                            curY = w.GetVerticalPosition(true);
    
                            //The current X is just the left margin
                            curX = doc.LeftMargin;
    
                            //Set a color fill
                            w.DirectContent.SetRGBColorStroke(0, 0, 0);
                            //Set the x,y of where to start drawing
                            w.DirectContent.MoveTo(curX, curY);
                            //Draw a line
                            w.DirectContent.LineTo(doc.PageSize.Width - doc.RightMargin, curY);
                            //Fill the line in
                            w.DirectContent.Stroke();
    
                            //Add another paragraph
                            doc.Add(new Paragraph("It was the word of times"));
    
                            //Repeat the above. curX never really changes unless you modify the document's margins
                            curY = w.GetVerticalPosition(true);
    
                            w.DirectContent.SetRGBColorStroke(0, 0, 0);
                            w.DirectContent.MoveTo(curX, curY);
                            w.DirectContent.LineTo(doc.PageSize.Width - doc.RightMargin, curY);
                            w.DirectContent.Stroke();
    
    
                            //Close the document
                            doc.Close();
                        }
                    }
                }
    
                this.Close();
            }
        }
    }
