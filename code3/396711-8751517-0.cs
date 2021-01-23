    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Drawing.Drawing2D;
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
                //Our working folder
                string workingFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                //Large image to add to sample PDF
                string largeImage = Path.Combine(workingFolder, "LargeImage.jpg");
                //Name of large PDF to create
                string largePDF = Path.Combine(workingFolder, "Large.pdf");
                //Name of compressed PDF to create
                string smallPDF = Path.Combine(workingFolder, "Small.pdf");
    
                //Create a sample PDF containing our large image, for demo purposes only, nothing special here
                using (FileStream fs = new FileStream(largePDF, FileMode.Create, FileAccess.Write, FileShare.None)) {
                    using (Document doc = new Document()) {
                        using (PdfWriter writer = PdfWriter.GetInstance(doc, fs)) {
                            doc.Open();
    
                            iTextSharp.text.Image importImage = iTextSharp.text.Image.GetInstance(largeImage);
                            doc.SetPageSize(new iTextSharp.text.Rectangle(0, 0, importImage.Width, importImage.Height));
                            doc.SetMargins(0, 0, 0, 0);
                            doc.NewPage();
                            doc.Add(importImage);
    
                            doc.Close();
                        }
                    }
                }
    
                //Now we're going to open the above PDF and compress things
    
                //Bind a reader to our large PDF
                PdfReader reader = new PdfReader(largePDF);
                //Create our output PDF
                using (FileStream fs = new FileStream(smallPDF, FileMode.Create, FileAccess.Write, FileShare.None)) {
                    //Bind a stamper to the file and our reader
                    using (PdfStamper stamper = new PdfStamper(reader, fs)) {
                        //NOTE: This code only deals with page 1, you'd want to loop more for your code
                        //Get page 1
                        PdfDictionary page = reader.GetPageN(1);
                        //Get the xobject structure
                        PdfDictionary resources = (PdfDictionary)PdfReader.GetPdfObject(page.Get(PdfName.RESOURCES));
                        PdfDictionary xobject = (PdfDictionary)PdfReader.GetPdfObject(resources.Get(PdfName.XOBJECT));
                        if (xobject != null) {
                            PdfObject obj;
                            //Loop through each key
                            foreach (PdfName name in xobject.Keys) {
                                obj = xobject.Get(name);
                                if (obj.IsIndirect()) {
                                    //Get the current key as a PDF object
                                    PdfDictionary imgObject = (PdfDictionary)PdfReader.GetPdfObject(obj);
                                    //See if its an image
                                    if (imgObject.Get(PdfName.SUBTYPE).Equals(PdfName.IMAGE)) {
                                        //NOTE: There's a bunch of different types of filters, I'm only handing the simplest one here which is basically raw JPG, you'll have to research others
                                        if (imgObject.Get(PdfName.FILTER).Equals(PdfName.DCTDECODE)) {
                                            //Get the raw bytes of the current image
                                            byte[] oldBytes = PdfReader.GetStreamBytesRaw((PRStream)imgObject);
                                            //Will hold bytes of the compressed image later
                                            byte[] newBytes;
                                            //Wrap a stream around our original image
                                            using (MemoryStream sourceMS = new MemoryStream(oldBytes)) {
                                                //Convert the bytes into a .Net image
                                                using (System.Drawing.Image oldImage = Bitmap.FromStream(sourceMS)) {
                                                    //Shrink the image to 90% of the original
                                                    using (System.Drawing.Image newImage = ShrinkImage(oldImage, 0.9f)) {
                                                        //Convert the image to bytes using JPG at 85%
                                                        newBytes = ConvertImageToBytes(newImage, 85);
                                                    }
                                                }
                                            }
                                            //Create a new iTextSharp image from our bytes
                                            iTextSharp.text.Image compressedImage = iTextSharp.text.Image.GetInstance(newBytes);
                                            //Kill off the old image
                                            PdfReader.KillIndirect(obj);
                                            //Add our image in its place
                                            stamper.Writer.AddDirectImageSimple(compressedImage, (PRIndirectReference)obj);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
    
                this.Close();
            }
    
            //Standard image save code from MSDN, returns a byte array
            private static byte[] ConvertImageToBytes(System.Drawing.Image image, long compressionLevel) {
                if (compressionLevel < 0) {
                    compressionLevel = 0;
                } else if (compressionLevel > 100) {
                    compressionLevel = 100;
                }
                ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
    
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, compressionLevel);
                myEncoderParameters.Param[0] = myEncoderParameter;
                using (MemoryStream ms = new MemoryStream()) {
                    image.Save(ms, jgpEncoder, myEncoderParameters);
                    return ms.ToArray();
                }
    
            }
            //standard code from MSDN
            private static ImageCodecInfo GetEncoder(ImageFormat format) {
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
                foreach (ImageCodecInfo codec in codecs) {
                    if (codec.FormatID == format.Guid) {
                        return codec;
                    }
                }
                return null;
            }
            //Standard high quality thumbnail generation from http://weblogs.asp.net/gunnarpeipman/archive/2009/04/02/resizing-images-without-loss-of-quality.aspx
            private static System.Drawing.Image ShrinkImage(System.Drawing.Image sourceImage, float scaleFactor) {
                int newWidth = Convert.ToInt32(sourceImage.Width * scaleFactor);
                int newHeight = Convert.ToInt32(sourceImage.Height * scaleFactor);
    
                var thumbnailBitmap = new Bitmap(newWidth, newHeight);
                using (Graphics g = Graphics.FromImage(thumbnailBitmap)) {
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    System.Drawing.Rectangle imageRectangle = new System.Drawing.Rectangle(0, 0, newWidth, newHeight);
                    g.DrawImage(sourceImage, imageRectangle);
                }
                return thumbnailBitmap;
            }
        }
    }
