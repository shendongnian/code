    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (Control c in this.Controls)
            {
                c.MouseDown += ShowMouseDown;    
            }
            this.MouseDown += (s, e) => { this.label1.Text = e.X + " " + e.Y; };
        }
        private void ShowMouseDown(object sender, MouseEventArgs e)
        {
            var x = e.X + ((Control)sender).Left;
            var y = e.Y + ((Control)sender).Top;
            this.label1.Text = x + " " + y;
        }
    }
