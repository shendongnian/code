    public partial class Form1 : Form
    {
        private DataTable dt;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.BindingContextChanged += new System.EventHandler(this.dataGridView1_BindingContextChanged);
            dt = new DataTable();
            DataColumn dc = dt.Columns.Add("C0");
            dc.AllowDBNull = false;
            dataGridView1.DataSource = dt.DefaultView;
        }
        private void dataGridView1_BindingContextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                DataTable boundTable = dataGridView1.DataSource as DataTable;
                if (boundTable == null)
                {
                    DataView dv = dataGridView1.DataSource as DataView;
                    if (dv != null)
                    {
                        boundTable = dv.Table;
                    }
                }
                if (boundTable != null)
                {
                    foreach (DataGridViewColumn c in dataGridView1.Columns)
                    {
                        if (c.IsDataBound)
                        {
                            DataColumn dc = boundTable.Columns[c.DataPropertyName];
                            if (!dc.AllowDBNull && dc.DataType == typeof(string))
                            {
                                c.DefaultCellStyle.DataSourceNullValue = string.Empty;
                                dc.DefaultValue = string.Empty;  // this value is pulled for new rows
                            }
                        }
                    }
                }
            }
        }
    }
