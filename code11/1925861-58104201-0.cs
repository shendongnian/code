    public class ProgressPanel : Panel
    {
        private float m_progress = 0;
        private Color m_progressColor = Color.Green;
        ProgressPanel()
        {
            InitializeComponent();
        }
    
        /// <summary>
        /// the progress value is between 0 & 100 inclusively
        /// </summary>
        public float Progress
        {
            get
            {
                return m_progress;
            }
            set
            {
                m_progress = value;
                this.Invalidate();
            }
        }
    
        public Color ProgressColor
        {
            get
            {
                return m_progressColor;
            }
            set
            {
                m_progressColor = value;
                this.Invalidate();
            }
        }
    
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
    
            e.Graphics.FillRectangle(new SolidBrush(ProgressColor), new Rectangle(new Point(), new Size((int)(Width * 100 / Progress), Height)));
        }
    
        private void InitializeComponent()
        {
            this.Paint += panel1_Paint;
        }
    }
