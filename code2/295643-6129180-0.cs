    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        unsafe 
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                Bitmap tiffSource = new Bitmap("c:\\temp\\bw.tif");
                Bitmap image1 = new Bitmap(tiffSource.Width, tiffSource.Height);
                
                BitmapData d = tiffSource.LockBits(
                     new Rectangle(new Point(0, 0), tiffSource.Size),
                     ImageLockMode.ReadOnly,tiffSource.PixelFormat);
                for (int y = 0; y < tiffSource.Height; y++)
                {
                    byte* Column = (byte*)d.Scan0 + y*d.Stride;
    
                    for (int x = 0; x < (tiffSource.Width ); x++)
                        if ((Column[(int)(x / 8)] & (128 >> (x % 8))) !=0   )
                            image1.SetPixel((x), y, Color.FromArgb(0, 0, 0, 0));
                        else
                            image1.SetPixel((x), y, Color.FromArgb(0, 255, 255, 255));
                }
                tiffSource.UnlockBits(d);
                image1.Save("c:\\temp\\out.jpg");
            }
        }
    }
