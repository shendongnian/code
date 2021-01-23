    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1][0] = "1";
            dt.Rows[dt.Rows.Count - 1][1] = "Stackoverflow";
            dataGridView1.DataSource = dt;
        }
        string ID = string.Empty;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
        }
           private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Form2 frmTwo = new Form2(ID);
                frmTwo.Show();
            }
        }
    }
