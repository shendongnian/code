    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Windows.Forms;
    
    public class FlatClose : Control
    {
        private enum MouseState
        {
            None,
            Over,
            Down
        }
    
        private MouseState State = MouseState.None;
    
        public StringFormat CenterSF;
    
        protected override void OnMouseEnter(EventArgs e) { State = MouseState.Over; Invalidate(); }
    
        protected override void OnMouseDown(MouseEventArgs e) { State = MouseState.Down; Invalidate(); }
    
        protected override void OnMouseLeave(EventArgs e) { State = MouseState.None; Invalidate(); }
    
        protected override void OnMouseUp(MouseEventArgs e) { State = MouseState.Over; Invalidate(); }
    
        protected override void OnMouseMove(MouseEventArgs e) { base.OnMouseMove(e); Invalidate(); }
    
        protected override void OnClick(EventArgs e)
        {
            if (FindForm().WindowState == FormWindowState.Normal) { FindForm().Close(); }
        }
    
        protected override void OnResize(EventArgs e) => base.OnResize(e);
    
        private Color _BaseColor = Color.FromArgb(168, 35, 35);
        [Category("Colors"), DefaultValue(typeof(Color), "168, 35, 35")]
        public Color BaseColor
        {
            get => _BaseColor;
            set { _BaseColor = value; }
        }
    
        private Color _TextColor = Color.FromArgb(243, 243, 243);
        [Category("Colors"), DefaultValue(typeof(Color), "243, 243, 243")]
        public Color TextColor
        {
            get => _TextColor;
            set { _TextColor = value; }
        }
    
        public FlatClose()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            BackColor = Color.White;
            Size = new Size(18, 18);
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Font = new Font("Marlett", 10);
            //CenterSF = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }; //Centers Horizontally
            CenterSF = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }; //Centers Horizontally and Vertically
        }
    
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            //All these versions, produce the same output
    
            //Original version
            //{
            //    Bitmap B = new Bitmap(Width, Height);
            //    Graphics G = Graphics.FromImage(B);
    
            //    Rectangle Base = new Rectangle(0, 0, Width, Height);
    
            //    var _with3 = G;
            //    _with3.SmoothingMode = SmoothingMode.HighQuality;
            //    _with3.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //    _with3.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            //    _with3.Clear(BackColor);
    
            //    //-- Base
            //    _with3.FillRectangle(new SolidBrush(_BaseColor), Base);
    
            //    //-- X
            //    _with3.DrawString("r", Font, new SolidBrush(TextColor), new Rectangle(0, 0, Width, Height), CenterSF);
    
            //    //-- Hover/down
            //    switch (State)
            //    {
            //        case MouseState.Over:
            //            _with3.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), Base);
            //            break;
            //        case MouseState.Down:
            //            _with3.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), Base);
            //            break;
            //    }
    
            //    base.OnPaint(e);
            //    G.Dispose();
            //    e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //    e.Graphics.DrawImageUnscaled(B, 0, 0);
            //    B.Dispose();
            //}
    
            //Version not using a Bitmap
            //{
            //    Rectangle Base = new Rectangle(0, 0, Width, Height);
    
            //    e.Graphics.Clear(BackColor);
    
            //    e.Graphics.FillRectangle(new SolidBrush(_BaseColor), Base);
            //    e.Graphics.DrawString("r", Font, new SolidBrush(TextColor), Base, CenterSF); //-- X
            //    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, (State == MouseState.Down) ? Color.Black : Color.White)), Base);
            //}
    
            //Version using a Bitmap
            {
                //Why are you creating a bitmap and drawing that?  You can't just draw on controls surface?
                using (Bitmap B = new Bitmap(Width, Height))
                using (Graphics _with3 = Graphics.FromImage(B))
                {
                    Rectangle Base = new Rectangle(0, 0, Width, Height);
    
                    //Not going to tell the difference.  So, I disable them.
                    //_with3.SmoothingMode = SmoothingMode.HighQuality;
                    //_with3.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    //_with3.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    
                    _with3.Clear(BackColor);
    
                    _with3.FillRectangle(new SolidBrush(_BaseColor), Base); //-- Base
    
                    _with3.DrawString("r", Font, new SolidBrush(TextColor), Base, CenterSF); //-- X
    
                    _with3.FillRectangle(new SolidBrush(Color.FromArgb(30, ((State == MouseState.Down) ? Color.Black : Color.White))), Base); //-- Hover/down
    
                    //base.OnPaint(e);
                    //e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    e.Graphics.DrawImageUnscaled(B, 0, 0);
                }
            }
        }
    }
