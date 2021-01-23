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
          e.Graphics.DrawImage(bm,new Point(0,0));
        }
    
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
          //Change the colors a little bit on each KeyUp.
          //On NumPad1, change red.
          //On NumPad2, change green.
          //On NumPad3, change blue.
          //Mod with 256 to ensure a value between 0 and 255.
          int rInc = 0;
          int gInc = 0;
          int bInc = 0;
    
          switch (e.KeyCode)
          {
            case Keys.NumPad1:
              rInc = 20;
              break;
            case Keys.NumPad2:
              gInc = 20;
              break;
            case Keys.NumPad3:
              bInc = 20;
              break;
            default:
              break;
          }
    
          for (int x = 0; x < bm.Width; x++)
          {
            for (int y = 0; y < bm.Height; y++)
            {
              colors[x, y] = bm.GetPixel(x, y);
            }
          }
    
          for (int x = 0; x < bm.Width; x++)
          {
            for (int y = 0; y < bm.Height; y++)
            {
              Color c = colors[x, y];
    
              int r = (c.R + rInc) % 256;
              int g = (c.G + gInc) % 256;
              int b = (c.B + bInc) % 256;
    
              c = Color.FromArgb(255, r, g, b);
              bm.SetPixel(x, y, c);
            }
          }
    
          Invalidate();
        }
    
      }
