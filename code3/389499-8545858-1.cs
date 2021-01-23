    namespace WindowsFormsApplication4
    {
        using System.Collections.Generic;
        using System.Drawing;
        using System.Windows.Forms;
        public partial class Form1 : Form
        {
            private const string FILE_NAME = @"C:\Temp\Capture.png";
            private const double BW_THRESHOLD = 0.5;
            private readonly Color colorBlack =
              Color.FromArgb(255, 0, 0, 0);
            private readonly Color colorWhite =
              Color.FromArgb(255, 255, 255, 255);
             private readonly Bitmap originalImage;
            private readonly Bitmap convertedImage;
            private readonly List<Vertex> vertices = new List<Vertex>();
            public Form1()
            {
                InitializeComponent();
                pictureBox1.ImageLocation = FILE_NAME;
                this.originalImage = new Bitmap(FILE_NAME);
                this.convertedImage = this.Img2BW(this.originalImage, BW_THRESHOLD);
                foreach (Vertex vert in this.vertices)
                {
                    listBox1.Items.Add(vert.ToString());
                }
            }
            private Bitmap Img2BW(Bitmap imgSrc, double threshold)
            {
                int width = imgSrc.Width;
                int height = imgSrc.Height;
                Color pixel;
                Bitmap imgOut = new Bitmap(imgSrc);
                for (int row = 0; row < height - 1; row++)
                {
                    for (int col = 0; col < width - 1; col++)
                    {
                        pixel = imgSrc.GetPixel(col, row);
                        if (pixel.GetBrightness() < threshold)
                        {
                            this.vertices.Add(new Vertex(col, row));
                            imgOut.SetPixel(col, row, this.colorBlack);
                        }
                        else
                        {
                            imgOut.SetPixel(col, row, this.colorWhite);
                        }
                    }
                }
                 return imgOut;
            }
        }
        public class Vertex
        {
            public Vertex(int i, int j)
            {
                this.X = i;
                this.Y = j;
            }
            public int X { get; set; }
            public int Y { get; set; }
            public string ToString()
            {
                return string.Format("({0}/{1})", this.X, this.Y);
            }
        }
    }
