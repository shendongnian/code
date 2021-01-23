     DataSet ds; //class variable
        public Form1()
        {
            InitializeComponent();
            ds = new DataSet();
            //column 1 (normal textColumn):
            dataGridView1.Columns.Add("col1", "Column1");
            //column 2 (comboBox):
            DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
            comboCol.Name = "cmbColumn";
            comboCol.HeaderText = "combobox column";
            dataGridView1.Columns.Add(comboCol);
            //using dataTable for each datasource:             
            for (int i = 0; i < 10; i++)
            {
                string text = "item " + i; //data for text
                int[] data = { 1 * i, 2 * i, 3 * i }; //data for comboBox:
                //create new dataTable:
                DataTable table = new DataTable("table" + i);
                table.Columns.Add("column1", typeof(string));
                
                //fillig rows:
                foreach (int item in data)
                    table.Rows.Add(item);
                
                //add table to dataSet:
                ds.Tables.Add(table);
                //creating new row in dgv (text and comboBox):
                CreateCustomComboBoxDataSouce(i, text, table);
            }
        }
        private void CreateCustomComboBoxDataSouce(int row, string texst, DataTable table) //row index ,and two parameters
        {
            dataGridView1.Rows.Add(texst);
            DataGridViewComboBoxCell comboCell = dataGridView1[1, row] as DataGridViewComboBoxCell;
            comboCell.DataSource = new BindingSource(table, null);
            comboCell.DisplayMember = "column1"; //name of column indataTable to display!!
            comboCell.ValueMember = "column1"; // vlaue if needed 
            //(mostly you used these two propertes like: Name as DisplayMember, and Id as ValueMember)
        }
