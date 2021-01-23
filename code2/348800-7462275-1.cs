    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            UserControl1 control = new UserControl1();
            control.Dock = DockStyle.Fill;
            this.Controls.Add(control);
        }
    }
