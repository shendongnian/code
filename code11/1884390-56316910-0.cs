        private void Form1_Load(object sender, EventArgs e)
        {
            CreateDataTable();
            cbo1.SelectedIndex = -1;
        }
        private void CreateDataTable()
        {
            //Create new DataTable
            DataTable dt = new DataTable();
            //Add colums with column name and datatype
            dt.Columns.Add("Value", Type.GetType("System.Int32"));
            dt.Columns.Add("Name", Type.GetType("System.String"));
            //Add data
            object[] data = { 1, "Active" };
            dt.Rows.Add(data);
            object[] data2 = { 2, "Passive" };
            dt.Rows.Add(data2);
            //Bind to combo box
            cbo1.DataSource = dt;
            cbo1.DisplayMember = "Name";
            cbo1.ValueMember = "Value";
        }
        
        private void Cbo1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MessageBox.Show($"The display member is {((DataRowView)cbo1.SelectedItem)["Name"]}, The value member is {cbo1.SelectedValue}");
        }
