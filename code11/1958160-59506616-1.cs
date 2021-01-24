    public partial class Form1 : Form
    {
        private Dart dart;
        public Form1()
        {
            InitializeComponent();
            this.dart = new Dart();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // center the origin to the form
            e.Graphics.TranslateTransform(ClientSize.Width/2, ClientSize.Height/2);
            dart.PaintDart(e.Graphics);
        }
    }
