    public partial class Form1 : Form
    {
        private bool setcol;
        private bool painted;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            setcol = true;
            painted = false;
        }
        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            if (setcol && !painted)
            {
                painted = true;
                dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.Red;
            }
        }
    }
