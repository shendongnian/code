    public partial class Form2 : Form
    {
        private Brush brushToPaint;
        public Form2()
        {
            InitializeComponent();
            brushToPaint = SystemBrushes.Control;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(brushToPaint, this.DisplayRectangle);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            brushToPaint = Brushes.Black;
            InvokePaint(this, new PaintEventArgs(this.CreateGraphics(), this.DisplayRectangle));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            brushToPaint = SystemBrushes.Control;
            InvokePaint(this, new PaintEventArgs(this.CreateGraphics(), this.DisplayRectangle));
        }
    }
