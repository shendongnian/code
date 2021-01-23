      public partial class Form1 : Form
      {
        Bitmap bm;
        Color [,] colors;
    
        public Form1()
        {
          bm = (Bitmap)Bitmap.FromFile("x.bmp");
          colors = new Color[bm.Width, bm.Height];
    
          InitializeComponent();
        }
    
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
          for (int x = 0; x < bm.Width; x++)
          {
            for (int y = 0; y < bm.Height; y++)
            {
              colors[x,y] = bm.GetPixel(x,y);
            }
          }
          for (int x = 0; x < bm.Width; x++)
          {
            for (int y = 0; y < bm.Height; y++)
            {
              Color c = colors[x, y];
              c = Color.FromArgb(0,(c.R + 100) % 255, (c.G + 100) % 255, (c.B + 100) % 255);
              bm.SetPixel(x, y, c);
            }
          }
    
          e.Graphics.DrawImage(bm,new Point(0,0));
        }
    
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
          this.Refresh();
        }
      }
