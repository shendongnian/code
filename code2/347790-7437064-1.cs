    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.ContextMenuStrip.Opening += new CancelEventHandler(ContextMenuStrip_Opening);
        }
        private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                e.Cancel = true;
            }
        }
    }
   
