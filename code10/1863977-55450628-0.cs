    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var rectangle = new System.Drawing.Rectangle(100, 100, 200, 200);
            e.Graphics.DrawRectangle(System.Drawing.Pens.Black, rectangle);
            base.OnPaint(e);
        }
    }
