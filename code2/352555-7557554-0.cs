        void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void dataGridView1_CellValueChanged(object obj, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) //compare to checkBox column index
            {
                DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)dataGridView1[e.ColumnIndex, e.RowIndex];
                if (!DBNull.Value.Equals(cbx.Value) && (bool)cbx.Value == true)
                {                 
                    //checkBox is checked - do the code in here!
                }
                else
                {
                   //if checkBox is NOT checked (unchecked)
                }
            }
        }
