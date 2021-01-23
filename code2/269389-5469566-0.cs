    using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace MDITest
    {
      public partial class MDIChild : Form
      {
        private static TooltipForm _tooltip = new TooltipForm();
        private static Form _lastForm;
    
        private Image _lastSnapshot;
    
        public MDIChild()
        {
          InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
          if (m.Msg == WM_COMMAND && m.WParam.ToInt32() == SC_MINIMIZE)
          {
            OnMinimize(EventArgs.Empty);
          }
          else if (m.Msg == WM_NCMOUSEMOVE)
          {
            int x = m.LParam.ToInt32() & 0x0000ffff;
            int y = m.LParam.ToInt32() >> 16;
            OnNcMouseMove(new MouseEventArgs(MouseButtons.None, 0, x, y, 0));
          }
          base.WndProc(ref m);
        }
        protected virtual void OnNcMouseMove(MouseEventArgs e)
        {
          if (this.WindowState == FormWindowState.Minimized && _lastForm != this)
          {
            _lastForm = this;
            Point pt = MdiParent.PointToScreen(this.Location);
            ShowWindowTip(pt, _lastSnapshot);
          }
        }
        protected virtual void OnMinimize(EventArgs e)
        {
          _tooltip.Visible = false;
          if (_lastSnapshot == null)
          {
            _lastSnapshot = new Bitmap(100, 100);
          }
      
          using (Image windowImage = new Bitmap(ClientRectangle.Width, ClientRectangle.Height))
          using (Graphics windowGraphics = Graphics.FromImage(windowImage))
          using (Graphics tipGraphics = Graphics.FromImage(_lastSnapshot))
          {      
            Rectangle r = this.RectangleToScreen(ClientRectangle);
            windowGraphics.CopyFromScreen(new Point(r.Left, r.Top), Point.Empty, new Size(r.Width, r.Height));
            windowGraphics.Flush();
            float scaleX = 1;
            float scaleY = 1;
            if (ClientRectangle.Width > ClientRectangle.Height)
            {
              scaleY = (float)ClientRectangle.Height / ClientRectangle.Width;
            }
            else if (ClientRectangle.Height > ClientRectangle.Width)
            {
              scaleX = (float)ClientRectangle.Width / ClientRectangle.Height;
            }
            tipGraphics.DrawImage(windowImage, 0, 0, 100 * scaleX, 100 * scaleY);
          }
        }
        private static void ShowWindowTip(Point pt, Image image)
        {
          if (_tooltip.Visible)
          {
            _tooltip.Visible = false;
          }
      
          _tooltip.Image = image;
          _tooltip.Show();
          _tooltip.Location = new Point(pt.X, pt.Y - _tooltip.Height - 10);
        }
        private static int WM_NCMOUSEMOVE = 0x00A0;
        private static int WM_COMMAND = 0x0112;
        private static int SC_MINIMIZE = 0xf020;
      }
    }
