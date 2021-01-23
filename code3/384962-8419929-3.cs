    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using iTextSharp.text;
    using iTextSharp.text.html.simpleparser;
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
                //The two files that we are creating
                string file1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "File1.pdf");
                string file2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "File2.pdf");
    
                //Create a base file to write on top of
                using (FileStream fs = new FileStream(file1, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (Document doc = new Document(PageSize.LETTER))
                    {
                        using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                        {
                            doc.Open();
                            doc.Add(new Paragraph("Hello world"));
                            doc.Close();
                        }
                    }
                }
                
                //Bind a reader to our first document
                PdfReader reader = new PdfReader(file1);
    
                //Create our second document
                using (FileStream fs = new FileStream(file2, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (PdfStamper stamper = new PdfStamper(reader, fs))
                    {
                        StyleSheet styles = new StyleSheet();
                        //...styles omitted for brevity
    
                        //Our HTML
                        string html = "<table><tr><th>First Name</th><th>Last Name</th></tr><tr><td>Chris</td><td>Haas</td></tr></table>";
                        //ParseToList requires a StreamReader instead of just a string so just wrap it
                        using (StringReader sr = new StringReader(html))
                        {
                            //Get our raw PdfContentByte object letting us draw "above" existing content
                            PdfContentByte cb = stamper.GetOverContent(1);
                            //Create a new ColumnText object bound to the above PdfContentByte object
                            ColumnText ct = new ColumnText(cb);
                            //Get the dimensions of the first page of our source document
                            iTextSharp.text.Rectangle page1size = reader.GetPageSize(1);
                            //Create a single column object spanning the entire page
                            ct.SetSimpleColumn(0, 0, page1size.Width, page1size.Height);
    
                            ct.AddElement(new Paragraph("Hello world!"));
    
                            //Convert our HTML to iTextSharp elements
                            List<IElement> elements = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(sr, styles);
                            //Loop through each element (in this case there's actually just one PdfPTable)
                            foreach (IElement el in elements)
                            {
                                //If the element is a PdfPTable
                                if (el is PdfPTable)
                                {
                                    //Cast it
                                    PdfPTable tt = (PdfPTable)el;
                                    //Change the widths, these are relative width by the way
                                    tt.SetWidths(new float[] { 75, 25 });
                                }
                                //Add the element to the ColumnText
                                ct.AddElement(el);
                            }
                            //IMPORTANT, this actually commits our object to the PDF
                            ct.Go();
                        }
                    }
                }
    
                this.Close();
            }
        }
    }
