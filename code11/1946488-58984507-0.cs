    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Property to hold the current color.  This could be a private field also.
        public Color CurrentColor { get; set; } = Color.Red;
        //Used to generate a random number when the button is clicked.
        private Random rnd = new Random();
        //All painting of the form should be in this method.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Use the graphics event provided to you in PaintEventArgs
            Graphics paper = e.Graphics;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            Point m = new Point(w / 2, h / 2);
            int s = Math.Min(w, h) / 2;
            //It is important to dispose of any pens you create
            using (Pen myPen = new Pen(CurrentColor))
            {
                paper.DrawEllipse(myPen, m.X - s, m.Y - s, s * 2, s * 2);
            }
        }
        //When the button is clicked, the `CurrentColor` property is set to a random
        //color and the form is refreshed to get it to repaint itself.
        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            //Change the current color
            CurrentColor = Color.FromArgb(255, rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
            //Refresh the form so it repaints itself
            this.Refresh();
        }
    }
