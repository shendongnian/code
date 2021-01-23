            public void AddRowInDataTable(int SelectedIndex)
        {
            //Add the columns
            DataColumn col = null;
            //For each columns in the datagridveiw add a new column to data table
            foreach (DataGridViewColumn dgvCol in dataGridView1.Columns)
            {
                col = new DataColumn(dgvCol.Name);
                if (!Frm2.dt.Columns.Contains(dgvCol.Name))
                    Frm2.dt.Columns.Add(col);
            }
            //Add the selected row from the datagridview
            DataRow row = null;
            row = Frm2.dt.Rows.Add();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                row[column.Index] = dataGridView1.Rows[SelectedIndex].Cells[column.Index].Value;
            }
        }  
  
