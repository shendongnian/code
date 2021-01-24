    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(new Pen(Color.Red, 1), new Rectangle(0, 0, 200, 200));
        }
    }
}
    It is quiet easy to draw a circle on the form. But this seems to be a milling program, you should splicing the string to the machine, not the form.
