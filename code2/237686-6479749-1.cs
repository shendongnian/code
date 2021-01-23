    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Resize += Form1_Resize;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
        }
        private void Form1_Resize(object sender, System.EventArgs e)
        {
            this.Update();
        }
    }
