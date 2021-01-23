      public partial class Form1 : Form
      {
        public Bitmap m_bitmap;
        public Point m_lastPoint = Point.Empty;
    
        public Form1()
        {
          InitializeComponent();   
          m_bitmap = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
          using (Graphics g = Graphics.FromImage(m_bitmap))
            g.Clear(SystemColors.Window);
        }
    
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          e.Graphics.DrawImage(m_bitmap, new Point(0, 0));
        }
    
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
          m_lastPoint = e.Location;
        }
        
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
          if (e.Button == MouseButtons.Left)
          {
            using (Graphics g = Graphics.FromImage(m_bitmap))
              g.DrawLine(Pens.Black, m_lastPoint, e.Location);
            m_lastPoint = e.Location;    
            panel1.Invalidate();
          }
        }  
      }
