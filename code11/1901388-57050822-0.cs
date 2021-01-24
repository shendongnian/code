    for (int i = 0; i < dataManipulator.columnCheckedList.CheckedItems.Count; i++)
      {
           addRecordDataGridView.Rows.Add(visibleColumns[i]);
           getSqlColumnTypes += $"'{visibleColumns[i]}'";
           SqlDataAdapter sqladapter = new SqlDataAdapter($"{getSqlColumnTypes}", loginForm.connection = new SqlConnection($"Server = {loginForm.serverName.Text }; Database = { loginForm.DBNames.SelectedItem}; Trusted_Connection = True"));
           DataSet dt = new DataSet();
           sqladapter.Fill(dt);
           addRecordDataGridView.Rows[i].Cells[1].Value = dt.Tables[0].Rows[0][0].ToString();
           addRecordDataGridView.Rows[i].Cells[2].Tag = new DataGridViewTextBoxColumn();
       }
