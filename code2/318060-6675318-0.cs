        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (isLate(dataGridView1[6, e.RowIndex].Value.ToString()))
            {
                dataGridView1[0, e.RowIndex].Style.ForeColor = Color.Red;
                count++;
            }
        }
