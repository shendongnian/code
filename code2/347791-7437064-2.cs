    public partial class Form1 : Form
    {
        public Form1()
        {
            this.Load += new EventHandler(this.Form1_Load);
            this.InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add("col1");
            dt.Columns.Add("col2");
            dt.Rows.Add(new string[] { "test", "test" });
            dt.Rows.Add(new string[] { "test", "test" });
            dt.Rows.Add(new string[] { "test", "test" });
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.ContextMenuStrip.Opening += new CancelEventHandler(this.ContextMenuStrip_Opening);            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.ClearSelection();
        }
        private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                e.Cancel = true;
            }
        }
    }
   
