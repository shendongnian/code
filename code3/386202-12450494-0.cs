            // Prepare the DataViewGrid
            dataGridView1.Columns.Clear();
            // Add each column to the grid according to the data table structure
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
                DataGridViewCell dataGridViewCell = new DataGridViewTextBoxCell();
                dataGridViewColumn.DataPropertyName = dataTable.Columns[i].ColumnName;
                dataGridViewColumn.HeaderText = dataTable.Columns[i].ColumnName;
                dataGridViewColumn.CellTemplate = dataGridViewCell;
                dataGridViewColumn.Name = dataTable.Columns[i].ColumnName;
                dataGridView1.Columns.Add(dataGridViewColumn);
            }
            // Set the DataSource for the binding
            bindingSource1.DataSource = dataTable;
            // Prevent unwanted columns autogeneration
            dataGridView1.AutoGenerateColumns = false;
            // Provide the binding to the DataGridView
            dataGridView1.DataSource = bindingSource1;
