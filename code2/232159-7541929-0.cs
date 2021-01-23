    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            frm.VisibleChanged += formVisibleChanged;
        }
        private void formVisibleChanged(object sender, EventArgs e)
        {
            Form2 frm = (Form2)sender;
            if (!frm.Visible)
            {
                this.listBox1.Items.Add(frm.ReturnText);
                frm.Dispose();
            }
           
            
        }
    }
