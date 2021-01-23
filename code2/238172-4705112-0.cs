    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox tb = new TextBox();
            tb.Location = new Point(e.X, e.Y);
            tb.Width = 100;
            this.Controls.Add(tb);
        }
    }
