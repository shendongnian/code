    public partial class frmDataGridView : Form
    {
        public frmDataGridView()
        {
            InitializeComponent();
        }
        private void frmDataGridView_Load(object sender, EventArgs e)
        {
            // disable resizing of rows
            dataGridView1.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView1.RowTemplate.Height = 75; // set to preferred (your personal) default
            // datasource - structure
            DataTable table = new DataTable();
            table.Columns.Add("SR.NO", typeof(int));
            table.Columns.Add("NAME", typeof(int));
            table.Columns.Add("CLASS", typeof(int));
            table.Columns.Add("ROLL NO", typeof(int));
            table.Columns.Add("GR.NO", typeof(int));
            table.Columns.Add("ADHAAR CARD UID", typeof(int));
            table.Columns.Add("GENDER", typeof(int));
            table.Columns.Add("CONTACT", typeof(int));
            table.Columns.Add("ADDRESS", typeof(int));
            // datasource - data
            table.Rows.Add(1, 1, 1, 1, 1, 1, 1, 1, 1);
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].Width = 40; // set a specific width for first column in DataGridView
        }
    }
