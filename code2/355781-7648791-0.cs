    public partial class Form1 : Form
    {
        // Instantiate the DataSource that will be bound to the DataGrid
        DataSet dataSet = new DataSet("MyDataSet");
        DataTable dataTable = new DataTable("MyDataTable");
    
        public Form1()
        {
            InitializeComponent();
            
            this.dataSet.Tables.Add(this.dataTable);
            this.dataTable.Columns.Add(new DataColumn("Date"));
            // Bind the DataTable to the DataGrid
            this.dataGrid1.SetDataBinding(this.dataSet, "MyDataTable");
        }    
       
        private void button1_Click(object sender, EventArgs e)
        {
            // When the user clicks the button, add a new row to the DataTable
            DataRow dr = this.dataTable.NewRow();
            dr["Date"] = DateTime.Now;
            this.dataTable.Rows.Add(dr);
        }
    }
