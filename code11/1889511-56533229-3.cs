    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    [ToolboxItem(false)]
    public partial class frmRoundCorners : baseForm
    {
        private GraphicsPath pathRegion = new GraphicsPath(FillMode.Winding);
        private GraphicsPath pathBorder;
        Point pMousePosition = Point.Empty;
        public frmRoundCorners()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);
            InitializeComponent();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                pMousePosition = e.Location;
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                Point screenPos = PointToScreen(e.Location);
                this.Location = new Point(screenPos.X - pMousePosition.X, screenPos.Y - pMousePosition.Y);
            }
            base.OnMouseMove(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            RoundedCornerRectangle(this.ClientRectangle);
            RectangleF rect = pathRegion.GetBounds();
            float scaleX = 1 - ((BorderSize) / rect.Width);
            float scaleY = 1 - ((BorderSize) / rect.Height);
            using (Pen pen = new Pen(BorderColor, BorderSize))
            using (Pen penBorder = new Pen(InternalBorderColor, 2))
            using (Brush brush = new SolidBrush(FillColor))
            using (Matrix mx = new Matrix(scaleX, 0, 0, scaleY, (pen.Width / 2), (pen.Width / 2)))
            {
                e.Graphics.Transform = mx;
                e.Graphics.FillPath(brush, pathRegion);
                e.Graphics.DrawPath(penBorder, pathBorder);
                e.Graphics.DrawPath(pen, pathRegion);
            }
        }
        private void RoundedCornerRectangle(Rectangle r)
        {
            pathRegion = new GraphicsPath(FillMode.Alternate);
            float innerCurve = this.CurveAngle - this.m_PenSizeOffset;
            pathRegion.StartFigure();
            pathRegion.AddArc(r.X, r.Y, CurveAngle, CurveAngle, 180, 90);
            pathRegion.AddArc(r.Right - CurveAngle, r.Y, CurveAngle, CurveAngle, 270, 90);
            pathRegion.AddArc(r.Right - CurveAngle, r.Bottom - CurveAngle, CurveAngle, CurveAngle, 0, 90);
            pathRegion.AddArc(r.X, r.Bottom - CurveAngle, CurveAngle, CurveAngle, 90, 90);
            pathRegion.CloseFigure();
            pathBorder = new GraphicsPath();
            pathBorder.StartFigure();
            pathBorder.AddArc(r.X + m_PenSizeOffset, r.Y + m_PenSizeOffset, innerCurve, innerCurve, 180, 90);
            pathBorder.AddArc(r.Right - innerCurve - m_PenSizeOffset, r.Y + m_PenSizeOffset, innerCurve, innerCurve, 270, 90);
            pathBorder.AddArc(r.Right - innerCurve - m_PenSizeOffset, r.Bottom - innerCurve- m_PenSizeOffset, innerCurve, innerCurve, 0, 90);
            pathBorder.AddArc(r.X + m_PenSizeOffset, r.Bottom - innerCurve - m_PenSizeOffset, innerCurve, innerCurve, 90, 90);
            pathBorder.CloseFigure();
        }
    }
    public class baseForm : Form
    {
        private Color m_InternalBorderColor = Color.FromArgb(128, 128, 128);
        private Color m_BorderColor = Color.Red;
        private Color m_FillColor = Color.WhiteSmoke;
        private float m_PenSize = 6f;
        private float m_CurveAngle = 60.0f;
        internal float m_PenSizeOffset = 3f;
        public baseForm() => InitializeComponent();
        private void InitializeComponent() => FormBorderStyle = FormBorderStyle.None;
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(60.0f)]
        public virtual float CurveAngle
        {
            get => this.m_CurveAngle;
            set {
                this.m_CurveAngle = Math.Max(Math.Min(value, 180), 15);
                Invalidate();
            }
        }
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(6.0f)]
        public virtual float BorderSize
        {
            get => this.m_PenSize;
            set {
                this.m_PenSize = value;
                this.m_PenSizeOffset = value / 2.0f;
                this.Invalidate();
            }
        }
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color BorderColor
        {
            get => this.m_BorderColor;
            set {
                this.m_BorderColor = value;
                this.Invalidate();
            }
        }
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual Color FillColor
        {
            get => this.m_FillColor;
            set {
                this.m_FillColor = value;
                this.Invalidate();
            }
        }
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Get or Set the Color of the internal border")]
        public virtual Color InternalBorderColor
        {
            get => this.m_InternalBorderColor;
            set {
                this.m_InternalBorderColor = value;
                this.Invalidate();
            }
        }
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(FormBorderStyle.None)]
        public new FormBorderStyle FormBorderStyle
        {
            get => base.FormBorderStyle;
            set => base.FormBorderStyle = FormBorderStyle.None;
        }
    }
