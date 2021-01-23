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
    
                            //Create a standard two column table
                            PdfPTable t = new PdfPTable(2);
    
                            //Create an instance of our custom cell event class, passing in our main writer which is needed by the PdfShading object
                            var CE = new GradientBackgroundEvent(w);
    
                            //Set the default cell's event to our handler
                            t.DefaultCell.CellEvent = CE;
    
                            //Add cells normally
                            t.AddCell("Hello");
                            t.AddCell("World");
    
    
                            //Add the table to the document
                            doc.Add(t);
    
                            //Close the document
                            doc.Close();
                        }
                    }
                }
    
                this.Close();
            }
    
            public class GradientBackgroundEvent : IPdfPCellEvent
            {
                //Holds pointer to main PdfWriter object
                private PdfWriter w;
    
                //Constructor
                public GradientBackgroundEvent(PdfWriter w)
                {
                    this.w = w;
                }
    
                public void CellLayout(PdfPCell cell, Rectangle position, PdfContentByte[] canvases)
                {
                    //Create a shading object with cell-specific coords
                    PdfShading shading = PdfShading.SimpleAxial(w, position.Left, position.Bottom, position.Right, position.Top, BaseColor.BLUE, BaseColor.RED);
    
                    //Create a pattern from our shading object
                    PdfShadingPattern pattern = new PdfShadingPattern(shading);
    
                    //Create a color from our patter
                    ShadingColor color = new ShadingColor(pattern);
    
                    //Get the background canvas. NOTE, If using an older version of iTextSharp (4.x) you might need to get the canvas in a different way
                    PdfContentByte cb = canvases[PdfPTable.BACKGROUNDCANVAS];
    
                    //Set the background color of the given rectable to our shading pattern
                    position.BackgroundColor = color;
    
                    //Fill the rectangle
                    cb.Rectangle(position);
                }
            }
        }
    }
