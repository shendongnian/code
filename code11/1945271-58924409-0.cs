    public partial class ObjectMove : Form
    {
        public ObjectMove() => InitializeComponent();
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawRectangleRectangle(e);
        }
    
        private void DrawRectangleRectangle(PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            Rectangle rect = new Rectangle(0, 0, 200, 200);
            e.Graphics.DrawRectangle(blackPen, rect);
        }
    }
