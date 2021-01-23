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
                string inputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "input.pdf");
                string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "output.pdf");
    
                PdfReader pdfReader = new PdfReader(inputFile);
                using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (PdfStamper stamper = new PdfStamper(pdfReader, fs))
                    {
                        int PageCount = pdfReader.NumberOfPages;
                        for (int x = 1; x <= PageCount; x++)
                        {
                            PdfContentByte cb = stamper.GetOverContent(x);
                            iTextSharp.text.Rectangle rectangle = pdfReader.GetPageSizeWithRotation(x);
                            rectangle.BackgroundColor = BaseColor.BLACK;
                            cb.Rectangle(rectangle);
                        }
                    }
                }
    
                this.Close();
            }
        }
    }
