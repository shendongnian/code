    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace floorDrawer
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ResizeRedraw = DoubleBuffered = true;
            Width = 800;
            Height = 600;
            Paint += new PaintEventHandler(Form1_Paint);
        }
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            // a few parameters that control the projection transform
            // these are the parameters that you can modify to change 
            // the output
            double cz = 10; // distortion
            double m = 1000; // magnification, usually around 1000 (the pixel width of the monitor)
            double y0 = -100; // floor height
            string texturePath = @"c:\pj\Hydrangeas.jpg";//@"c:\pj\Chrysanthemum.jpg";
            // screen size
            int height = ClientSize.Height;
            int width = ClientSize.Width;
            // center of screen
            double cx = width / 2;
            double cy = height / 2;
            // render destination
            var dst = new Bitmap(width, height);
            // source texture
            var src = Bitmap.FromFile(texturePath) as Bitmap;
            // texture dimensions
            int tw = src.Width;
            int th = src.Height;
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    double v = m * y0 / (y - cy) - cz;
                    double u = (x - cx) * (v + cz) / m;
                    int uu = ((int)u % tw + tw) % tw;
                    int vv = ((int)v % th + th) % th;
                    // The following .SetPixel() and .GetPixel() are painfully slow
                    // You can replace this whole loop with an equivalent implementation
                    // using pointers inside unsafe{} code to make it much faster.
                    // Note that by casting u and v into integers, we are performing
                    // a nearest pixel interpolation...  It's sloppy but effective.
                    dst.SetPixel(x, y, src.GetPixel(uu, vv));
                }
            // draw result on the form
            e.Graphics.DrawImage(dst, 0, 0);
        }
    }
    }
