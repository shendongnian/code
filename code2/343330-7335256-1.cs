    //Paragraph Example
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Forms;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                //PDF file to output
                string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Output.pdf");
    
                //Create a basic stream to write to
                using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    //Create a new PDF document
                    using (Document doc = new Document())
                    {
                        //Bind a the document to the stream
                        using (PdfWriter w = PdfWriter.GetInstance(doc, fs))
                        {
                            //Open our PDF for writing
                            doc.Open();
    
                            //Insert a new page into our output PDF
                            doc.NewPage();
    
                            //Right-pad each "column" for a total of 20 characters
                            string FormatString = "{0,-20}{1,-20}{2,-20}";
    
                            //Add the first row
                            doc.Add(new Paragraph(String.Format(FormatString, "ColumnA", "ColumnB", "ColumnC")));
    
                            //Add a blank line
                            doc.Add(new Paragraph(""));
    
                            //Add the two data rows
                            doc.Add(new Paragraph(String.Format(FormatString, "Value1", "Value1", "Value1")));
                            doc.Add(new Paragraph(String.Format(FormatString, "Value2", "Value2", "Value2")));
                            
    
                            //Close our output PDF
                            doc.Close();
                        }
                    }
                }
                this.Close();
            }
        }
    }
