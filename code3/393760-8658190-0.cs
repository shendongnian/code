    using System;
    using System.ComponentModel;
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
                string baseFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "StartFile.pdf");
                string secondFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SecondFile.pdf");
                string TestImage = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.jpg");
    
                //Create a very simple PDF with a single form field called "firstName"
                using (FileStream fs = new FileStream(baseFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (Document doc = new Document(PageSize.LETTER))
                    {
                        using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                        {
                            doc.Open();
                            writer.AddAnnotation(new TextField(writer, new iTextSharp.text.Rectangle(0, 0, 100, 100), "firstName").GetTextField());
                            doc.Close();
                        }
                    }
                }
    
    
                //Create a second file "filling out" the form above
                using (FileStream fs = new FileStream(secondFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (PdfStamper stamper = new PdfStamper(new PdfReader(baseFile), fs))
                    {
                        //GetFieldPositions returns an array of field positions if you are using 5.0 or greater
                        //This line does a lot and should really be broken up for null-checking
                        iTextSharp.text.Rectangle rect = stamper.AcroFields.GetFieldPositions("firstName")[0].position;
                        //Create an image
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(TestImage);
                        //Scale it
                        img.ScaleAbsolute(rect.Width, rect.Height);
                        //Position it
                        img.SetAbsolutePosition(rect.Left, rect.Bottom);
                        //Add it to page 1 of the document
                        stamper.GetOverContent(1).AddImage(img);
                        stamper.Close();
                    }
                }
                
                this.Close();
            }
        }
    }
