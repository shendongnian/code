        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            string data = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if(!ValidateData(data))
                e.Cancel = true;
        }
        private bool ValidateData(string data)
        {
            // do validation which u want to do.
        }
        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            string data = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            SaveData(data);
        }
        private void SaveData(string data)
        {
            // save data
        }
