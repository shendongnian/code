    using System;
    using System.ComponentModel;
    using System.Data;
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
                //Create a simple test file
                string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.pdf");
    
                using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (Document doc = new Document(PageSize.LETTER))
                    {
                        using (PdfWriter w = PdfWriter.GetInstance(doc, fs))
                        {
                            doc.Open();
                            doc.Add(new Paragraph("This is a test"));
                            doc.Close();
                        }
                    }
                }
    
                //Create a new file from our test file with highlighting
                string highLightFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Highlighted.pdf");
    
                //Bind a reader and stamper to our test PDF
                PdfReader reader = new PdfReader(outputFile);
                
                using (FileStream fs = new FileStream(highLightFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (PdfStamper stamper = new PdfStamper(reader, fs))
                    {
                        //Create a rectangle for the highlight. NOTE: Technically this isn't used but it helps with the quadpoint calculation
                        iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(60.6755f, 749.172f, 94.0195f, 735.3f);
                        //Create an array of quad points based on that rectangle. NOTE: The order below doesn't appear to match the actual spec but is what Acrobat produces
                        float[] quad = { rect.Left, rect.Bottom, rect.Right, rect.Bottom, rect.Left, rect.Top, rect.Right, rect.Top };
    
                        //Create our hightlight
                        PdfAnnotation highlight = PdfAnnotation.CreateMarkup(stamper.Writer, rect, null, PdfAnnotation.MARKUP_HIGHLIGHT, quad);
    
                        //Set the color
                        highlight.Color = BaseColor.YELLOW;
    
                        //Add the annotation
                        stamper.AddAnnotation(highlight,1);
                    }
                }
    
                this.Close();
            }
        }
    }
