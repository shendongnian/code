    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.IO;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    namespace WindowsFormsApplication1 {
        public partial class Form1 : Form {
            public Form1() {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e) {
                //File to write out
                string outputFilename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Images.pdf");
    
                //Standard PDF creation
                using (FileStream fs = new FileStream(outputFilename, FileMode.Create, FileAccess.Write, FileShare.None)) {
                    //NOTE, we are not setting a document size here at all, we'll do that later
                    using (Document doc = new Document()) {
                        using (PdfWriter writer = PdfWriter.GetInstance(doc, fs)) {
                            doc.Open();
    
                            //Create a simple bitmap with two red arrows stretching across it
                            using (Bitmap b1 = new Bitmap(100, 400)) {
                                using (Graphics g1 = Graphics.FromImage(b1)) {
                                    using(Pen p1 = new Pen(Color.Red,10)){
                                        p1.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                                        p1.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                                        g1.DrawLine(p1, 0, b1.Height / 2, b1.Width, b1.Height / 2);
                                        g1.DrawLine(p1, b1.Width / 2, 0, b1.Width / 2, b1.Height);
    
                                        //Create an iTextSharp image from the bitmap (we need to specify a background color, I think it has to do with transparency)
                                        iTextSharp.text.Image img1 = iTextSharp.text.Image.GetInstance(b1, BaseColor.WHITE);
                                        //Absolutely position the image
                                        img1.SetAbsolutePosition(0, 0);
                                        //Change the page size for the next page added to match the source image
                                        doc.SetPageSize(new iTextSharp.text.Rectangle(0, 0, b1.Width, b1.Height, 0));
                                        //Add a new page
                                        doc.NewPage();
                                        //Add the image directly to the writer
                                        writer.DirectContent.AddImage(img1);
                                    }
                                }
                            }
    
                            //Repeat the above but with a larger and wider image
                            using (Bitmap b2 = new Bitmap(4000, 1000)) {
                                using (Graphics g2 = Graphics.FromImage(b2)) {
                                    using (Pen p2 = new Pen(Color.Red, 10)) {
                                        p2.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                                        p2.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                                        g2.DrawLine(p2, 0, b2.Height / 2, b2.Width, b2.Height / 2);
                                        g2.DrawLine(p2, b2.Width / 2, 0, b2.Width / 2, b2.Height);
                                        iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(b2, BaseColor.WHITE);
                                        img2.SetAbsolutePosition(0, 0);
                                        doc.SetPageSize(new iTextSharp.text.Rectangle(0, 0, b2.Width, b2.Height, 0));
                                        doc.NewPage();
                                        writer.DirectContent.AddImage(img2);
                                    }
                                }
                            }
                            
    
                            doc.Close();
                        }
                    }
                }
                this.Close();
            }
        }
    }
