        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SelectedIndexs.Contains(e.RowIndex))
            {
                SelectedIndexs.Remove(e.RowIndex);
            }
            else
            {
                SelectedIndexs.Add(e.RowIndex);
            }
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.Selected = SelectedIndexs.Contains(row.Index);
            }
        }
