        private void CreateAndBind()
        {
            DataTable table = GetDataToDataTable();
            //then bind it to dgv:
            dgv.DataSource = new BindingSource(table, null);
            //create events for dgv:
            dgv.CurrentCellDirtyStateChanged += new EventHandler(dgv_CurrentCellDirtyStateChanged);
            dgv.CellValueChanged += new EventHandler(dgv_CellValueChanged);
        }
        private DataTable GetDataToDataTable()
        {
            //get data from dataBase, or what ever...   
            table.Columns.Add("column1", typeof(stirng));
            table.Columns.Add("column2", typeof(bool));
            //adding some exmaple rows:
            table.Rows.Add("item 1", true);
            table.Rows.Add("item 2", false);
            return table;
        }
        void dgv_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void dgv_CellValueChanged(object obj, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) //compare to checkBox column index
            {
                DataGridViewCheckBoxCell check = dataGridView1[0, e.RowIndex] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(check.Value) == true)
                {
                    //If tick is added!
                    //
                }
            }
        }
