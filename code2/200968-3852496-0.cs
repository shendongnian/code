    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (Control c in this.Controls)
            {
                c.MouseDown += ShowMouseDown;    
            }
            this.MouseDown += ShowMouseDown;
        }
        private void ShowMouseDown(object sender, MouseEventArgs e)
        {
            this.label1.Text = e.X + " " + e.Y;
        }
    }
