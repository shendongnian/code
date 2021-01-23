    public partial class AquaButton : UserControl
    {
        private bool m_IsMouseOver = false;
        protected string m_text = string.Empty;
        [Category("Appearance")]
        [Description("Gets / Sets Button Text")]
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
        Bindable(true)]
        public override string Text
        {
            get { return m_text; }
            set { m_text = value; this.Invalidate(); }
        }
        public AquaButton()
        {
            InitializeComponent();
        }
        private void AquaButton_Resize(object sender, EventArgs e)
        {
            this.Width = 130;
            this.Height = 28;
        }
        private void AquaButton_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            ExtendedGraphics eg = new ExtendedGraphics(g);
            //SolidBrush br1 = new SolidBrush(Color.FromArgb(130, 125,236,255));
            LinearGradientBrush br1 = new LinearGradientBrush(
                new Point(60, 0),
                new Point(60, 28),
                Color.FromArgb(125, 236, 255),
                Color.FromArgb(0, 130, 255)
                );
            eg.FillRoundRectangle(br1, 1, 1, 124, 25, 12);
            if (m_IsMouseOver)
            {
                GraphicsPath GP = new GraphicsPath();
                GP.AddEllipse(25, -7, 70, 70);
                PathGradientBrush PGB = new PathGradientBrush(GP);
                PGB.CenterColor = Color.FromArgb(0, 255, 0);
                PGB.SurroundColors = new Color[] { Color.FromArgb(0, 0, 0, 0) };
                g.FillRectangle(PGB, 0, 0, 130, 26);
            }
            Pen pn1 = new Pen(Color.Black, 2f);
            eg.DrawRoundRectangle(pn1, 1, 1, 124, 25, 12);
            Rectangle rect1 = new Rectangle(0, 0, this.Width, this.Height);
            StringFormat strForm = new StringFormat();
            strForm.Alignment = StringAlignment.Center;
            strForm.LineAlignment = StringAlignment.Center;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.DrawString(m_text,
                new Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold),
                Brushes.Black,
                rect1,
                strForm
                );
        }
        private void AquaButton_MouseEnter(object sender, EventArgs e)
        {
            m_IsMouseOver = true;
            this.Invalidate();
        }
        private void AquaButton_MouseLeave(object sender, EventArgs e)
        {
            m_IsMouseOver = false;
            this.Invalidate();
        }
    }
