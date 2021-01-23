    //PdfPTable Example
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
    
                            //Create a three column table
                            PdfPTable t = new PdfPTable(3);
    
                            //Remove the border from the table
                            t.DefaultCell.Border = 0;
    
                            //For the first row we some extra padding
                            t.DefaultCell.PaddingBottom = 10;
                            t.AddCell("ColumnA");
                            t.AddCell("ColumnB");
                            t.AddCell("ColumnC");
    
                            //Reset the padding for the remaining cells
                            t.DefaultCell.PaddingBottom = 0;
                            t.AddCell("Value1");
                            t.AddCell("Value1");
                            t.AddCell("Value1");
    
                            t.AddCell("Value2");
                            t.AddCell("Value2");
                            t.AddCell("Value2");
    
                            //Add the table to the document
                            doc.Add(t);
    
                            //Close our output PDF
                            doc.Close();
                        }
                    }
                }
                this.Close();
            }
        }
    }
