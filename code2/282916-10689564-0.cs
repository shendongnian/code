    public class Popup : Control
    {
        private class Const
        {
            public const int Height = 100;
            public static Color BarFrameColor = SystemColors.ControlDark;
            public static Color BarShadowColor = Color.Black;
            public static Color BackColor = SystemColors.Info;
            public static Color ForeColor = SystemColors.InfoText;
        }
        // [ gdi objects ]
        private Bitmap m_bmp;
        private Pen m_penShadow, m_penFrame;
        private Panel panel;
        private VScrollBar vScrollBar;
        private Label lblText;
        private bool scrolling;
        public string Text
        {
            get
            {
                return lblText.Text;
            }
            set
            {
                lblText.Text = value;
            }
        }
        public bool Scrolling
        {
            get
            {
                return this.scrolling;
            }
            set
            {
                this.scrolling = value;
            }
        }
        public Popup()
        {
            this.Hide();
            this.ForeColor = Const.ForeColor;
            this.BackColor = Const.BackColor;
            this.Height = Const.Height;
            this.panel = new Panel();
            this.panel.BackColor = Const.BackColor;
            this.panel.Location = new Point(2, 2);
            this.vScrollBar = new VScrollBar();
            this.vScrollBar.ValueChanged += new EventHandler(vScrollBar_ValueChanged);
            this.lblText = new Label();
            this.lblText.Location = new Point(0, 0);
            this.lblText.Text = "";
            this.panel.Controls.Add(lblText);
            this.Controls.Add(vScrollBar);
            this.Controls.Add(panel);
            CreateGdiObjects();
            this.Scrolling = false;
        }
        private void CreateGdiObjects()
        {
            // [ gdi objects ]
            this.m_penShadow = new Pen(Const.BarShadowColor);
            this.m_penFrame = new Pen(Const.BarFrameColor);
        }
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            // [ calculate layout ]
            this.Left = 0;
            if (this.Parent != null)
            {
                this.Width = this.Parent.Width;
                this.Top = this.Parent.Height - this.Height;
            }
            if (this.Scrolling)
            {
                this.vScrollBar.Size = new Size(12, this.Height - 4);
                this.vScrollBar.Location = new Point(this.Width - 2 - this.vScrollBar.Width, 2);
                this.panel.Size = new Size(this.Width - 4 - this.vScrollBar.Width, this.Height - 4);
                this.vScrollBar.Minimum = this.panel.Top;
                this.vScrollBar.Maximum = this.panel.Height;
                this.vScrollBar.Visible = true;
                this.lblText.Size = new Size(this.panel.Width, this.Height * 3);
            }
            else
            {
                this.panel.Size = new Size(this.Width - 4, this.Height - 4);
                this.vScrollBar.Visible = false;
                this.lblText.Size = this.panel.Size;
            }
            this.BringToFront();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // [ draw progress on memory bitmap ]
            CreateMemoryBitmap();
            Graphics g = Graphics.FromImage(this.m_bmp);
            DrawControl(g);
            // [ blit to screen ]
            e.Graphics.DrawImage(this.m_bmp, 0, 0);
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // [ don't pass to base since we paint everything, avoid flashing ]
        }
        private void CreateMemoryBitmap()
        {
            // [ see if need to create bitmap ]
            if (this.m_bmp == null || this.m_bmp.Width != this.Width || this.m_bmp.Height != this.Height)
                this.m_bmp = new Bitmap(this.Width, this.Height);
        }
        private void DrawControl(Graphics g)
        {
            g.Clear(this.BackColor);
            Rectangle rc = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            g.DrawRectangle(this.m_penShadow, rc);
            rc.Inflate(-1, -1);
            g.DrawRectangle(this.m_penFrame, rc);
        }
        private void vScrollBar_ValueChanged(object sender, System.EventArgs e)
        {
            this.lblText.Top = -this.vScrollBar.Value;
        }
    }
