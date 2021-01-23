    public class PictureBoxEx : Control
        {
            public PictureBoxEx()
            {
                this.SetStyle(ControlStyles.Selectable | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
                
                
            }
            
    
            protected override void OnClick(EventArgs e)
            {
                this.Select();
                base.OnClick(e);
            }
    
            private Image _Image;
            public Image Image
            {
                get
                {
                    return _Image;
                }
                set
                {
                    _Image = value;
                    this.Invalidate();
                }
            }
    
            private Point _ImageLocation = new Point(0,0);
            public Point ImageLocation
            {
                get
                {
                    return _ImageLocation;
                }
                set
                {
                    _ImageLocation = value;
                    this.Invalidate();
                }
            }
    
            private int _ImageLocationLeft = 0;
            public int ImageLocationLeft
            {
                get
                {
                    return _ImageLocationLeft;
                }
                set
                {
                    _ImageLocationLeft = value;
                    ImageLocation = new Point(value, ImageLocationTop);
                }
            }
    
            private int _ImageLocationTop = 0;
            public int ImageLocationTop
            {
                get
                {
                    return _ImageLocationTop;
                }
                set
                {
                    _ImageLocationTop = value;
                    ImageLocation = new Point(ImageLocationLeft, value);
                }
            }
    
            protected override void OnPaint(PaintEventArgs pe)
            {
                if (Image != null)
                {
                    pe.Graphics.DrawImage(Image, ImageLocation);
                }
                base.OnPaint(pe);
            }
    
            protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
            {
                if (e.KeyData == Keys.Up || e.KeyData == Keys.Down || e.KeyData == Keys.Left || e.KeyData == Keys.Right)
                e.IsInputKey = true;
                base.OnPreviewKeyDown(e);
            }
        }
