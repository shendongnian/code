    namespace SmartDeviceProject1
    {
        public partial class Form1 : Form
        {
    
        DataTable dataTable = new DataTable();
        public Form1()
        {
            InitializeComponent();
            
            dataTable.Columns.Add("MortgageTypeName", typeof(String));
            dataTable.Columns.Add("FixedRate", typeof(Int32));
            dataTable.Columns.Add("ARMRate", typeof(Int32));
            DataRow dr = dataTable.NewRow();
            dr["MortgageTypeName"] = "Fixed";
            dr["FixedRate"] = 5;
            dr["ARMRate"] = 10;
            dataTable.Rows.Add(dr);
            DataGridTableStyle tableStyle = new DataGridTableStyle(); 
            tableStyle.MappingName = dataTable.TableName; 
            
            GridColumnStylesCollection columnStyles = tableStyle.GridColumnStyles; 
            
            DataGridTextBoxColumn columnStyle = new DataGridTextBoxColumn(); 
            columnStyle.MappingName = "MortgageTypeName"; 
            columnStyle.HeaderText = "Years"; 
            columnStyle.Width = 58; 
            columnStyles.Add(columnStyle); 
            
            columnStyle = new DataGridTextBoxColumn(); 
            columnStyle.MappingName = "FixedRate"; 
            columnStyle.HeaderText = "Fixed(%)"; 
            columnStyle.Width = 64; 
            columnStyles.Add(columnStyle); 
            
            columnStyle = new DataGridTextBoxColumn(); 
            columnStyle.MappingName = "ARMRate"; 
            columnStyle.HeaderText = "ARM(%)"; 
            columnStyle.Width = 64; 
            columnStyles.Add(columnStyle); 
            
            GridTableStylesCollection tableStyles = dgRates.TableStyles; 
            tableStyles.Add(tableStyle); dgRates.PreferredRowHeight = 16; 
            dgRates.RowHeadersVisible = false; 
            dgRates.DataSource = dataTable;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow dr = dataTable.NewRow();
            dr["MortgageTypeName"] = "Fixed";
            dr["FixedRate"] = 6;
            dr["ARMRate"] = 11;
            dataTable.Rows.Add(dr);
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            dataTable.Rows.Clear();
        }
    }
